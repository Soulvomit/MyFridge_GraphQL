using MyFridge_Library_Client_MAUI.ClientRepository.Abstract;
using MyFridge_Library_Client_MAUI.ClientRepository.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using System.Net.Http.Json;

namespace MyFridge_Library_Client_MAUI.ClientRepository
{
    public class RecipeClientRepository : ClientRepository<RecipeCto>, IRecipeClientRepository
    {
        public RecipeClientRepository(string baseAddress) : base(baseAddress) { }

        public IEnumerable<RecipeCto> MakeableLazies { get; private set; }

        public async Task<IEnumerable<RecipeCto>> GetMakeableAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetMakeable?userId={userId}");
            response.EnsureSuccessStatusCode();
            MakeableLazies = await response.Content.ReadFromJsonAsync<IEnumerable<RecipeCto>>();
            return MakeableLazies;
        }
    }
}
