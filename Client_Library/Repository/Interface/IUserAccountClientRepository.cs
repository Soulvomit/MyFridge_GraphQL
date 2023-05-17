using Client_Library.Repository.Interface.Base;
using Client_Model.Model;

namespace Client_Library.Repository.Interface
{
    public interface IUserAccountClientRepository : IClientRepository<UserAccountCto>
    {
        public Task<UserAccountCto> ChangeAsync(UserAccountCto cto, string nodeItems, bool core = false);
        public Task<UserAccountCto> GetByEmailAsync(string email, string nodeItems);
        public Task<UserAccountCto> AddIngredientAmountAsync(
            UserAccountCto cto, 
            IngredientAmountCto ingredientAmountCto, 
            string nodeItems, 
            bool newBatch = false);
        public Task<bool> RemoveIngredientAmountAsync(
            UserAccountCto cto, 
            IngredientAmountCto ingredientAmountCto, 
            string nodeItems);
    }
}
