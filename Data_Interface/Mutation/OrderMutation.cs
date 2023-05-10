using Client_Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class OrderMutation : MutationQL
    {
        public OrderMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<OrderCto?> CreateOrderAsync(ApplicationDbContext context, OrderCto cto)
        {
            cto.Id = 0;
            OrderDto? dto = _map.Order.ToDto(from: cto);

            await context.Orders.AddAsync(dto);
            await context.SaveChangesAsync();
            return _map.Order.ToCto(from: dto);
        }
        public async Task<OrderCto?> UpdateOrderAsync(ApplicationDbContext context, OrderCto cto)
        {
            OrderDto? dto = _map.Order.ToDto(from: cto);

            context.Orders.Update(dto);
            await context.SaveChangesAsync();
            return _map.Order.ToCto(from: dto);
        }
        public async Task<bool> DeleteOrderAsync(ApplicationDbContext context, OrderCto cto)
        {
            OrderDto? dto = await context.Orders.FindAsync(cto.Id);

            if (dto == null)
                return false;

            context.Orders.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
