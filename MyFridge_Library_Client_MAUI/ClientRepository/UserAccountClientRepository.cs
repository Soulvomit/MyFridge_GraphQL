using MyFridge_Library_Client_MAUI.ClientRepository.Abstract;
using MyFridge_Library_Client_MAUI.ClientRepository.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using System.Net.Http.Json;

namespace MyFridge_Library_Client_MAUI.ClientRepository
{
    public class UserAccountClientRepository : ClientRepository<UserAccountCto>, IUserAccountClientRepository
    {
        public UserAccountClientRepository(string baseAddress) : base(baseAddress) { }

        public async Task<UserAccountCto> GetByEmailAsync(string email)
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetByEmail?email={email}");
            response.EnsureSuccessStatusCode();
            Lazy = await response.Content.ReadFromJsonAsync<UserAccountCto>();
            return Lazy;
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