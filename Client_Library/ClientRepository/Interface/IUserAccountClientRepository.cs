using Client_Library.Interface.Base;
using Client_Model;

namespace Client_Library.Interface
{
    public interface IUserAccountClientRepository : IClientRepository<UserAccountCto>
    {
        public Task<UserAccountCto> GetByEmailAsync(string email);
        public Task<IngredientAmountCto> AddIngredientAmountAsync(IngredientAmountCto dto, int id);
        public Task<bool> RemoveIngredientAmountAsync(int id, int ingredientId, int removeAmount, bool force = false);
    }
}
