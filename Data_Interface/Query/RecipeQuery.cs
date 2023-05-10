using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class RecipeQuery : QueryQL
    {
        public RecipeQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<RecipeQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<RecipeCto?> GetRecipeAsync(RecipeCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            RecipeDto? dto = await context.Recipes.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.Recipe.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RecipeCto?> GetRecipes(ApplicationDbContext context)
        {
            var mappingExpression = _map.Recipe.ProjectToCto();
            IQueryable<RecipeCto?> ctos = context.Recipes.Select(mappingExpression);

            return ctos;
        }
    }
}