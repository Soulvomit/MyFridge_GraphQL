using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model.Model;
using System.Net.Http.Json;

namespace Client_Library.Repository
{
    public class UserAccountClientRepository : ClientRepository<UserAccountCto>, IUserAccountClientRepository
    {
        public UserAccountClientRepository(string baseAddress) : base(baseAddress) { }

        public async Task<UserAccountCto> GetByEmailAsync(string email)
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetByEmail?email={email}");
            response.EnsureSuccessStatusCode();
            CachedItem = await response.Content.ReadFromJsonAsync<UserAccountCto>();
            return CachedItem;
        }
        public async Task<IngredientAmountCto> AddIngredientAmountAsync(IngredientAmountCto dto, int id)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/{ResolveName}Ingredients/Upsert?id={id}", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IngredientAmountCto>();
        }
        public async Task<bool> RemoveIngredientAmountAsync(int id, int ingredientId, int removeAmount, bool force = false)
        {
            var response = await _httpClient.DeleteAsync($"api/{ResolveName}Ingredients/Delete?id={id}&ingredientAmountId={ingredientId}&removeAmount={removeAmount}&forceRemove={force}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<bool>();
        }
    }
}