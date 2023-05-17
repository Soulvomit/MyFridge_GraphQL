using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class UserMutation : MutationQL
    {
        public UserMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<UserAccountCto?> CreateUserAccountAsync(ApplicationDbContext context, UserAccountCto cto)
        {
            if (cto == null) return null;

            cto.Id = default;
            UserAccountDto? dto = _map.User.ToDto(from: cto);

            if (dto == null) return null;

            await context.Users.AddAsync(dto);

            await context.SaveChangesAsync();
            return _map.User.ToCto(from: dto);
        }
        public async Task<UserAccountCto?> UpdateUserAccountAsync(ApplicationDbContext context, UserAccountCto cto)
        {
            if (cto == null) return null;

            UserAccountDto? dto = _map.User.ToDto(from: cto);

            if (dto == null) return null;

            context.Users.Update(dto);

            await context.SaveChangesAsync();
            return _map.User.ToCto(from: dto);
        }
        public async Task<UserAccountCto?> ChangeUserAccountAsync(ApplicationDbContext context, UserAccountCto cto)
        {
            if (cto == null) return null;

            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.FirstName = cto.FirstName;
            dto.LastName = cto.LastName;
            dto.Password = cto.Password;
            dto.PhoneNumber = ulong.Parse(cto.PhoneNumber);
            dto.Email = cto.Email;
            dto.BirthDate = cto.BirthDate ?? default;
            dto.Address = _map.Address.ToDto(cto.Address);

            await context.SaveChangesAsync();
            return _map.User.ToCto(from: dto);
        }
        public async Task<bool> DeleteUserAccountAsync(ApplicationDbContext context, UserAccountCto cto)
        {
            if (cto == null) return false;

            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);

            if (dto == null) return false;

            context.Users.Remove(dto);

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<UserAccountCto?> ChangeUserAccountCoreAsync(ApplicationDbContext context, UserAccountCto cto)
        {
            if (cto == null) return null;

            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.FirstName = cto.FirstName;
            dto.LastName = cto.LastName;
            dto.Password = cto.Password;
            dto.PhoneNumber = ulong.Parse(cto.PhoneNumber);
            dto.Email = cto.Email;
            dto.BirthDate = cto.BirthDate ?? default;

            await context.SaveChangesAsync();
            return _map.User.ToCto(from: dto);
        }

        public async Task<UserAccountCto?> ChangeUserAddressAsync(
            ApplicationDbContext context, 
            UserAccountCto cto,
            AddressCto addressCto)
        {
            if (cto == null) return null;

            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);

            if (dto == null) return null;

            AddressDto? addressDto = await context.Addresses.FindAsync(addressCto.Id);

            if (addressDto == null)
            {
                dto.Address = _map.Address.ToDto(addressCto);
            }
            else
            {
                dto.Address = addressDto;
            }

            await context.SaveChangesAsync();
            return _map.User.ToCto(dto);
        }

        public async Task<UserAccountCto?> AddAmountUserAsync
        (
            ApplicationDbContext context, 
            UserAccountCto cto,
            IngredientAmountCto ingredientAmountCto,
            bool newBatch = false 
        )
        {
            //ensure amount is positive
            if (ingredientAmountCto.Amount <= 0) return null;
            //ensure user exists
            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);
            if (dto == null) return null;
            //ensure ingredient exists
            IngredientDto? ingredientDto = await context.Ingredients.FindAsync(ingredientAmountCto.Id);
            if (ingredientDto == null) return null;
            //get any ingredient amount which matches the ingredient 
            IngredientAmountDto? ingredientAmountDto = 
                dto.IngredientAmounts.FirstOrDefault(i => i.Ingredient?.Id  == ingredientDto.Id);
            //if the ingredient exists on user and a new batch is not specified
            if (ingredientAmountDto != null && !newBatch)
            {
                //add the amount to the existing ingredient amount, and set a new expiration 
                ingredientAmountDto.Amount += ingredientAmountCto.Amount;
                ingredientAmountDto.ExpirationDate = ingredientAmountCto.ExpirationDate;
            }
            //if the ingredient does not exist on user or if an new batch is specified
            else
            {
                //create and add a new ingredient amount batch to the user 
                dto.IngredientAmounts.Add
                (
                    new IngredientAmountDto
                    {
                        Amount = ingredientAmountCto.Amount,
                        Ingredient = ingredientDto,
                        ExpirationDate = ingredientAmountCto.ExpirationDate
                    }
                );
            }
            //save changes to db
            await context.SaveChangesAsync();
            //return a copy of the user
            return _map.User.ToCto(dto);
        }
        public async Task<UserAccountCto?> RemoveAmountUserAsync
        (
            ApplicationDbContext context,
            UserAccountCto cto, 
            IngredientAmountCto ingredientAmountCto
        )
        {
            //ensure amount is positive
            if (ingredientAmountCto.Amount <= 0) return null;
            //ensure user exists
            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);
            if (dto == null) return null;
            //get all ingredient amounts which matches the ingredient, and sort by expiration date 
            List<IngredientAmountDto> matches = dto.IngredientAmounts
                .Where(ia => ia.Ingredient?.Id == ingredientAmountCto.Id)
                .OrderBy(ia => ia.ExpirationDate)
                .ToList();
            //ensure the user has the ingredient
            if (matches.Count < 1) return null;
            //count the user's total amount of the ingredient
            float totalAmount = 0;
            foreach (IngredientAmountDto ia in matches)
                totalAmount += ia.Amount;
            //ensure the user has enough
            if (totalAmount < ingredientAmountCto.Amount) return null;
            //remove ingredient amounts, starting with the oldest ingredients
            foreach (IngredientAmountDto ingredientAmountDto in matches)
            {
                //remove the oldest ingredient amount from the required amount 
                ingredientAmountCto.Amount -= ingredientAmountDto.Amount;
                //if required amount reached
                if (ingredientAmountCto.Amount <= 0)
                {
                    //remove the overshoot amount from current ingredient
                    ingredientAmountDto.Amount = -ingredientAmountCto.Amount;
                    //if the amount goes down to 0 
                    if (ingredientAmountDto.Amount == 0)
                    {
                        //remove the amount from user and db
                        dto.IngredientAmounts.Remove(matches[0]);
                        context.IngredientAmounts.Remove(matches[0]);
                    }
                    //break the loop
                    break;
                }
                //remove the amount from user and db
                dto.IngredientAmounts.Remove(ingredientAmountDto);
                context.IngredientAmounts.Remove(ingredientAmountDto);
            }
            //save changes to db
            await context.SaveChangesAsync();
            //return a copy of the user
            return _map.User.ToCto(dto);
        }
    }
}
