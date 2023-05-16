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
            if (cto == null) return null;

            cto.Id = default;
            OrderDto? dto = _map.Order.ToDto(from: cto);

            if (dto == null) return null;

            await context.Orders.AddAsync(dto);

            await context.SaveChangesAsync();
            return _map.Order.ToCto(from: dto);
        }
        public async Task<OrderCto?> UpdateOrderAsync(ApplicationDbContext context, OrderCto cto)
        {
            if (cto == null) return null;

            OrderDto? dto = _map.Order.ToDto(from: cto);

            if (dto == null) return null;

            context.Orders.Update(dto);

            await context.SaveChangesAsync();
            return _map.Order.ToCto(from: dto);
        }
        public async Task<bool> DeleteOrderAsync(ApplicationDbContext context, OrderCto cto)
        {
            if (cto == null) return false;

            OrderDto? dto = await context.Orders.FindAsync(cto.Id);

            if (dto == null) return false;

            context.Orders.Remove(dto);

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<OrderCto?> UpdateOrderCoreAsync(ApplicationDbContext context, OrderCto cto)
        {
            if (cto == null) return null;

            OrderDto? dto = await context.Orders.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.Status = (EOrderStatus)cto.Status;

            await context.SaveChangesAsync();
            return _map.Order.ToCto(from: dto);
        }
        public async Task<OrderCto?> AddOrderGroceryAsync(ApplicationDbContext context, OrderCto cto, GroceryDto groceryCto)
        {
            if (cto == null || groceryCto == null) return null;

            OrderDto? dto = await context.Orders.FindAsync(cto.Id);
            GroceryDto? groceryDto = await context.Groceries.FindAsync(groceryCto.Id);

            if (dto == null) return null;

            if (groceryDto == null)
                dto.Groceries.Add(groceryCto);
            else
                dto.Groceries.Add(groceryDto);

            await context.SaveChangesAsync();
            return _map.Order.ToCto(from: dto);
        }

        public async Task<bool> RemoveOrderGroceryAsync(ApplicationDbContext context, OrderCto cto, GroceryDto groceryCto)
        {
            if (cto == null || groceryCto == null) return false;

            OrderDto? dto = await context.Orders.FindAsync(cto.Id);

            if (dto == null) return false;

            GroceryDto? groceryDto = await context.Groceries.FindAsync(groceryCto.Id);

            if (groceryDto == null) return false;

            dto.Groceries.Remove(groceryDto);

            await context.SaveChangesAsync();
            return true;
        }
    }
}
