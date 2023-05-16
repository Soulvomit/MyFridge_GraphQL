using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Data_Model.Enum;
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
            if (cto == null) return null;

            cto.Id = default;
            IngredientDto? dto = _map.Ingredient.ToDto(from: cto);

            if (dto == null) return null;

            await context.Ingredients.AddAsync(dto);

            await context.SaveChangesAsync();
            return _map.Ingredient.ToCto(from: dto);
        }
        public async Task<IngredientCto?> UpdateIngredientAsync(ApplicationDbContext context, IngredientCto cto)
        {
            if (cto == null) return null;

            IngredientDto? dto = _map.Ingredient.ToDto(from: cto);

            if (dto == null) return null;

            context.Ingredients.Update(dto);

            await context.SaveChangesAsync();
            return _map.Ingredient.ToCto(from: dto);
        }
        public async Task<bool> DeleteIngredientAsync(ApplicationDbContext context, IngredientCto cto)
        {
            if (cto == null) return false;

            IngredientDto? dto = await context.Ingredients.FindAsync(cto.Id);

            if (dto == null) return false;

            context.Ingredients.Remove(dto);

            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IngredientCto?> ChangeIngredientCoreAsync(ApplicationDbContext context, IngredientCto cto)
        {
            if (cto == null) return null;

            IngredientDto? dto = await context.Ingredients.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.Name = cto.Name;
            dto.Unit = (EUnit)cto.Unit;
            dto.Category = cto.Category;

            await context.SaveChangesAsync();
            return _map.Ingredient.ToCto(from: dto);
        }
    }
}
