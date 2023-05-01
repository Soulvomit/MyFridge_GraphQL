using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class IngredientQuery : QueryQL
    {
        public IngredientQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<IngredientQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<IngredientCto?> GetIngredientAsync(IngredientCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            IngredientDto? dto = await context.Ingredients.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.Ingredient.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<IngredientCto?> GetIngredients(ApplicationDbContext context)
        {
            IQueryable<IngredientCto?> ctos = context.Ingredients.Select(dto => _map.Ingredient.ToCto(dto));

            return ctos;
        }
    }
}