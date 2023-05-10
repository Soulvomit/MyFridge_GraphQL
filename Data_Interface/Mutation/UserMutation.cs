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
        public async Task<UserAccountCto> AddIngredientAmountAsync(ApplicationDbContext context, UserAccountCto cto, IngredientAmountCto ingredientAmountCto)
        {
            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);
            if (dto == null) return null;
            IngredientDto ingredientDto = await context.Ingredients.FindAsync(ingredientAmountCto.Ingredient.Id);
            if (ingredientDto == null) return null;
            

            dto.IngredientAmounts.Add(new IngredientAmountDto { 
                Amount = ingredientAmountCto.Amount, 
                Ingredient = ingredientDto,
                ExpirationDate = ingredientAmountCto.ExpirationDate
            });

            await context.SaveChangesAsync();
            return _map.User.ToCto(dto);
        }
        public async Task<UserAccountCto?> BatchIngredientAmountAsync(ApplicationDbContext context, 
            UserAccountCto cto, int ingredientId, float amount, DateTime? expirationDate = null)
        {
            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);
            if (dto == null) return null;
            
            IngredientDto? ingredientDto = await context.Ingredients.FindAsync(ingredientId);
            if (ingredientDto == null) return null;

            IngredientAmountDto? ingredientAmountDto = 
                dto.IngredientAmounts.FirstOrDefault(i => i.Ingredient.Id == ingredientDto.Id);

            if (ingredientAmountDto != null)
            {
                ingredientAmountDto.Amount += amount;

                if(ingredientAmountDto.Amount <= 0)
                {
                    dto.IngredientAmounts.Remove(ingredientAmountDto);
                }
            }
            else
            {
                if (amount > 0)
                {
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
            }

            await context.SaveChangesAsync();
            return _map.User.ToCto(dto);
        }
    }
}
