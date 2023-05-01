using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class GroceryQuery : QueryQL
    {
        public GroceryQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<GroceryQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<GroceryCto?> GetGroceryAsync(GroceryCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            GroceryDto? dto = await context.Groceries.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.Grocery.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<GroceryCto?> GetGroceries(ApplicationDbContext context)
        {
            IQueryable<GroceryCto?> ctos = context.Groceries.Select(dto => _map.Grocery.ToCto(dto));

            return ctos;
        }
    }
}
