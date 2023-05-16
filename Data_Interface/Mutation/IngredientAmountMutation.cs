using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class IngredientAmountMutation : MutationQL
    {
        public IngredientAmountMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<IngredientAmountCto?> CreateIngredientAmountAsync(ApplicationDbContext context, IngredientAmountCto cto)
        {
            if (cto == null) return null;

            cto.Id = default;
            IngredientAmountDto? dto = _map.IngredientAmount.ToDto(from: cto);

            if (dto == null) return null;

            await context.IngredientAmounts.AddAsync(dto);

            await context.SaveChangesAsync();
            return _map.IngredientAmount.ToCto(from: dto);
        }
        public async Task<IngredientAmountCto?> UpdateIngredientAmountAsync(ApplicationDbContext context, IngredientAmountCto cto)
        {
            if (cto == null) return null;

            IngredientAmountDto? dto = _map.IngredientAmount.ToDto(from: cto);

            if (dto == null) return null;

            context.IngredientAmounts.Update(dto);

            await context.SaveChangesAsync();
            return _map.IngredientAmount.ToCto(from: dto);
        }
        public async Task<bool> DeleteIngredientAmountAsync(ApplicationDbContext context, IngredientAmountCto cto)
        {
            if (cto == null) return false;

            IngredientAmountDto? dto = await context.IngredientAmounts.FindAsync(cto.Id);

            if (dto == null) return false;

            context.IngredientAmounts.Remove(dto);

            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IngredientAmountCto?> ChangeIngredientAmountCoreAsync(ApplicationDbContext context, IngredientAmountCto cto)
        {
            if (cto == null) return null;

            IngredientAmountDto? dto = await context.IngredientAmounts.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.Amount = cto.Amount;
            dto.ExpirationDate = cto.ExpirationDate;

            await context.SaveChangesAsync();
            return _map.IngredientAmount.ToCto(from: dto);
        }
        public async Task<IngredientAmountCto?> ChangeIngredientAmountIngredientAsync(
            ApplicationDbContext context,
            IngredientAmountCto cto,
            IngredientCto ingredientCto)
        {
            if (cto == null) return null;

            IngredientAmountDto? dto = await context.IngredientAmounts.FindAsync(cto.Id);

            if (dto == null) return null;

            IngredientDto? ingredientDto = await context.Ingredients.FindAsync(ingredientCto.Id);

            if (ingredientDto == null)
            {
                dto.Ingredient = _map.Ingredient.ToDto(ingredientCto);
            }
            else
            {
                dto.Ingredient = ingredientDto;
            }

            await context.SaveChangesAsync();
            return _map.IngredientAmount.ToCto(dto);
        }
    }
}
