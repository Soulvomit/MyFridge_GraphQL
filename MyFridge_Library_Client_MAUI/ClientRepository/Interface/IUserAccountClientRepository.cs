using MyFridge_Library_Client_MAUI.ClientRepository.Interface.Base;
using MyFridge_Library_Client_MAUI.ClientModel;

namespace MyFridge_Library_Client_MAUI.ClientRepository.Interface
{
    public interface IUserAccountClientRepository : IClientRepository<UserAccountCto>
    {
        public Task<UserAccountCto> GetByEmailAsync(string email);
        public Task<IngredientAmountCto> AddIngredientAmountAsync(IngredientAmountCto dto, int id);
        public Task<bool> RemoveIngredientAmountAsync(int id, int ingredientId, int removeAmount, bool force = false);
    }
}
