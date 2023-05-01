using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataRepository.Interface.Base;

namespace MyFridge_Library_Data.DataRepository.Interface
{
    public interface IUserAccountDataRepository : IDataRepository<UserAccountDto>
    {
        public Task<UserAccountDto?> GetByEmailAsync(string email);
        public Task<bool> BatchIngredientAmountAsync(int id, IngredientAmountDto addEntity);
        public Task<bool> AddIngredientAmountAsync(int id, IngredientAmountDto addEntity);
        public Task<bool> RemoveAmountAsync(int id, int ingredientAmountId, float removeAmount, bool forceRemove = true);
        public Task<bool> RemoveIngredientAmountAsync(int id, IngredientAmountDto removeEntity);
        public Task<bool> RemoveIngredientAmountAsync(int id, int ingredientAmountId);
        public Task<bool> AddOrderAsync(int id, OrderDto addEntity);
        public Task<bool> RemoveOrderAsync(int id, OrderDto removeEntity);
    }
}
