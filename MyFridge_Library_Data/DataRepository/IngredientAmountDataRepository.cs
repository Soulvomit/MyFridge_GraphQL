using Microsoft.Extensions.Logging;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataRepository.Abstract;
using MyFridge_Library_Data.DataRepository.Interface;

namespace MyFridge_Library_Data.DataRepository
{
    public class IngredientAmountDataRepository : DataRepository<IngredientAmountDto>, IIngredientAmountDataRepository

    {
        public IngredientAmountDataRepository(ApplicationDbContext context, ILogger log)
            : base(context, log)
        {
        }

        public override async Task<bool> UpdateAsync(IngredientAmountDto updateEntity)
        {
            if (updateEntity == null) return false;

            IngredientAmountDto? entityInDb = await dbSet.FindAsync(updateEntity.Id);

            if (entityInDb == null) return false;

            entityInDb.Amount = updateEntity.Amount;
            entityInDb.ExpirationDate = updateEntity.ExpirationDate;

            return true;
        }
    }
}
