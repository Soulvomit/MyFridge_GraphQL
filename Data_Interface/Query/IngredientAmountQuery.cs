using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class IngredientAmountQuery : QueryQL
    {
        public IngredientAmountQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<IngredientAmountQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<IngredientAmountCto?> GetIngredientAmountAsync(IngredientAmountCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            IngredientAmountDto? dto = await context.IngredientAmounts.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.IngredientAmount.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<IngredientAmountCto?> GetIngredientAmounts(ApplicationDbContext context)
        {
            var mappingExpression = _map.IngredientAmount.ProjectToCto();
            IQueryable<IngredientAmountCto?> ctos = context.IngredientAmounts.Select(mappingExpression);

            return ctos;
        }
    }
}