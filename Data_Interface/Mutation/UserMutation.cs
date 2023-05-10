using Client_Model;
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
            cto.Id = 0;
            UserAccountDto? dto = _map.User.ToDto(from: cto);

            await context.Users.AddAsync(dto);
            await context.SaveChangesAsync();
            return _map.User.ToCto(from: dto);
        }
        public async Task<UserAccountCto?> UpdateUserAccountAsync(ApplicationDbContext context, UserAccountCto cto)
        {
            UserAccountDto? dto = _map.User.ToDto(from: cto);

            context.Users.Update(dto);
            await context.SaveChangesAsync();
            return _map.User.ToCto(from: dto);
        }
        public async Task<bool> DeleteUserAccountAsync(ApplicationDbContext context, UserAccountCto cto)
        {
            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);

            if (dto == null)
                return false;

            context.Users.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<UserAccountCto?> AddAmountAsync
        (
            ApplicationDbContext context, 
            UserAccountCto cto, 
            int ingredientId, 
            float amount,
            DateTime? expirationDate = null,
            bool newBatch = false 
        )
        {
            //ensure amount is positive
            if (amount <= 0) return null;
            //ensure user exists
            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);
            if (dto == null) return null;
            //ensure ingredient exists
            IngredientDto? ingredientDto = await context.Ingredients.FindAsync(ingredientId);
            if (ingredientDto == null) return null;
            //get any ingredient amount which matches the ingredient 
            IngredientAmountDto? ingredientAmountDto = 
                dto.IngredientAmounts.FirstOrDefault(i => i.Ingredient.Id == ingredientDto.Id);
            //if the ingredient exists on user and a new batch is not specified
            if (ingredientAmountDto != null && !newBatch)
            {
                //add the amount to the existing ingredient amount, and set a new expiration 
                ingredientAmountDto.Amount += amount;
                ingredientAmountDto.ExpirationDate = expirationDate;
            }
            //if the ingredient does not exist on user or if an new batch is specified
            else
            {
                //create and add a new ingredient amount batch to the user 
                dto.IngredientAmounts.Add
                (
                    new IngredientAmountDto
                    {
                        Amount = amount,
                        Ingredient = ingredientDto,
                        ExpirationDate = expirationDate
                    }
                );
            }
            //save changes to db
            await context.SaveChangesAsync();
            //return a copy of the user
            return _map.User.ToCto(dto);
        }
        public async Task<UserAccountCto?> RemoveAmountAsync
        (
            ApplicationDbContext context,
            UserAccountCto cto, 
            int ingredientId, 
            float amount
        )
        {
            //ensure amount is positive
            if (amount <= 0) return null;
            //ensure user exists
            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);
            if (dto == null) return null;
            //get all ingredient amounts which matches the ingredient, and sort by expiration date 
            List<IngredientAmountDto> matches = dto.IngredientAmounts
                .Where(ia => ia.Ingredient.Id == ingredientId)
                .OrderBy(ia => ia.ExpirationDate)
                .ToList();
            //ensure the user has the ingredient
            if (matches.Count < 1) return null;
            //count the user's total amount of the ingredient
            float totalAmount = 0;
            foreach (IngredientAmountDto ia in matches)
                totalAmount += ia.Amount;
            //ensure the user has enough
            if (totalAmount < amount) return null;
            //remove ingredient amounts, starting with the oldest ingredients
            foreach (IngredientAmountDto ia in matches)
            {
                //remove the oldest ingredient amount from the required amount 
                amount -= ia.Amount;
                //if required amount reached
                if (amount <= 0)
                {
                    //remove the overshoot amount from current ingredient
                    ia.Amount = -amount;
                    //if the amount goes down to 0 
                    if (ia.Amount == 0)
                    {
                        //remove the amount from user and db
                        dto.IngredientAmounts.Remove(matches[0]);
                        context.IngredientAmounts.Remove(matches[0]);
                    }
                    //break the loop
                    break;
                }
                //remove the amount from user and db
                dto.IngredientAmounts.Remove(ia);
                context.IngredientAmounts.Remove(ia);
            }
            //save changes to db
            await context.SaveChangesAsync();
            //return a copy of the user
            return _map.User.ToCto(dto);
        }
    }
}
