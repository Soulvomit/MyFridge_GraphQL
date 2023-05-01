using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class OrderQuery : QueryQL
    {
        public OrderQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<OrderQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<OrderCto?> GetOrderAsync(OrderCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            OrderDto? dto = await context.Orders.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.Order.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<OrderCto?> GetOrders(ApplicationDbContext context)
        {
            IQueryable<OrderCto?> ctos = context.Orders.Select(dto => _map.Order.ToCto(dto));

            return ctos;
        }
    }
}
