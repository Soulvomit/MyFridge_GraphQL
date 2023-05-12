using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class RecipeMutation : MutationQL
    {
        public RecipeMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<RecipeCto?> CreateRecipeAsync(ApplicationDbContext context, RecipeCto cto)
        {
            cto.Id = 0;
            RecipeDto? dto = _map.Recipe.ToDto(from: cto);

            await context.Recipes.AddAsync(dto);
            await context.SaveChangesAsync();
            return _map.Recipe.ToCto(from: dto);
        }
        public async Task<RecipeCto?> UpdateRecipeAsync(ApplicationDbContext context, RecipeCto cto)
        {
            RecipeDto? dto = _map.Recipe.ToDto(from: cto);

            context.Recipes.Update(dto);
            await context.SaveChangesAsync();
            return _map.Recipe.ToCto(from: dto);
        }
        public async Task<bool> DeleteRecipeAsync(ApplicationDbContext context, RecipeCto cto)
        {
            RecipeDto? dto = await context.Recipes.FindAsync(cto.Id);

            if (dto == null)
                return false;

            context.Recipes.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
