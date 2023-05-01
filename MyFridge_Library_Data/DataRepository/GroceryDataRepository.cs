using Microsoft.Extensions.Logging;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataRepository.Abstract;
using MyFridge_Library_Data.DataRepository.Interface;

namespace MyFridge_Library_Data.DataRepository
{
    public class GroceryDataRepository : DataRepository<GroceryDto>, IGroceryDataRepository
    {
        public GroceryDataRepository(ApplicationDbContext context, ILogger log)
            : base(context, log)
        {
        }
        public override async Task<bool> UpdateAsync(GroceryDto updateEntity)
        {
            if (updateEntity == null) return false;

            GroceryDto? entityInDb = await dbSet.FindAsync(updateEntity.Id);

            if (entityInDb == null) return false;

            entityInDb.Brand = updateEntity.Brand;
            entityInDb.SalePrice = updateEntity.SalePrice;
            entityInDb.ItemIdentifier = updateEntity.ItemIdentifier;
            entityInDb.ImageUrl = updateEntity.ImageUrl;

            return true;
        }
    }
}