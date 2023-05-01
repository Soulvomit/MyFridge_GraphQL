using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataRepository.Abstract;
using MyFridge_Library_Data.DataRepository.Interface;

namespace MyFridge_Library_Data.DataRepository
{
    public class OrderDataRepository : DataRepository<OrderDto>, IOrderDataRepository
    {
        public OrderDataRepository(ApplicationDbContext context, ILogger log)
            : base(context, log)
        {
        }

        public override async Task<bool> UpdateAsync(OrderDto updateEntity)
        {
            if (updateEntity == null) return false;

            OrderDto? entityInDb = await dbSet.FindAsync(updateEntity.Id);
            if (entityInDb == null) return false;

            entityInDb.Status = updateEntity.Status;

            return true;
        }

        #region Grocery
        public async Task<bool> AddGroceryAsync(int id, GroceryDto addEntity)
        {
            if (addEntity == null) return false;

            Task<OrderDto?> t1 = GetAsync(id);
            Task<GroceryDto?> t2 = _context.Groceries
                .Where(grocery => grocery.Id == addEntity.Id)
                .FirstOrDefaultAsync();

            await Task.WhenAll(t1, t2);

            OrderDto? orderEntityInDb = t1.Result;
            GroceryDto? groceryEntityInDb = t2.Result;

            if (orderEntityInDb == null) return false;

            if (groceryEntityInDb == null)
                orderEntityInDb.Groceries.Add(addEntity);
            else
                orderEntityInDb.Groceries.Add(groceryEntityInDb);
            return true;
        }

        public async Task<bool> RemoveGroceryAsync(int id, int groceryId)
        {
            OrderDto? entityInDb = await GetAsync(id);
            if (entityInDb == null) return false;

            GroceryDto? groceryEntityInDb = await _context.Groceries.FindAsync(groceryId);
            if (groceryEntityInDb == null) return false;

            entityInDb.Groceries.Remove(groceryEntityInDb);

            return true;
        }
        #endregion
    }
}
