using Client_Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class IngredientMutation : MutationQL
    {
        public IngredientMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<IngredientCto?> CreateIngredientAsync(ApplicationDbContext context, IngredientCto cto)
        {
            cto.Id = 0;
            IngredientDto? dto = _map.Ingredient.ToDto(from: cto);

            await context.Ingredients.AddAsync(dto);
            await context.SaveChangesAsync();
            return _map.Ingredient.ToCto(from: dto);
        }
        public async Task<IngredientCto?> UpdateIngredientAsync(ApplicationDbContext context, IngredientCto cto)
        {
            IngredientDto? dto = _map.Ingredient.ToDto(from: cto);

            context.Ingredients.Update(dto);
            await context.SaveChangesAsync();
            return _map.Ingredient.ToCto(from: dto);
        }
        public async Task<bool> DeleteIngredientAsync(ApplicationDbContext context, IngredientCto cto)
        {
            IngredientDto? dto = await context.Ingredients.FindAsync(cto.Id);

            if (dto == null)
                return false;

            context.Ingredients.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
