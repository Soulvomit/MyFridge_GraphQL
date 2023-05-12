using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class GroceryMutation : MutationQL
    {
        public GroceryMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<GroceryCto?> CreateGroceryAsync(ApplicationDbContext context, GroceryCto cto)
        {
            cto.Id = 0;
            GroceryDto? dto = _map.Grocery.ToDto(from: cto);

            await context.Groceries.AddAsync(dto);
            await context.SaveChangesAsync();
            return _map.Grocery.ToCto(from: dto);
        }
        public async Task<GroceryCto?> UpdateGroceryAsync(ApplicationDbContext context, GroceryCto cto)
        {
            GroceryDto? dto = _map.Grocery.ToDto(from: cto);

            context.Groceries.Update(dto);
            await context.SaveChangesAsync();
            return _map.Grocery.ToCto(from: dto);
        }
        public async Task<bool> DeleteGroceryAsync(ApplicationDbContext context, GroceryCto cto)
        {
            GroceryDto? dto = await context.Groceries.FindAsync(cto.Id);

            if (dto == null)
                return false;

            context.Groceries.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
