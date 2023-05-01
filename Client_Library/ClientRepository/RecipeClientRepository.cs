using Client_Library.Abstract;
using Client_Library.Interface;
using Client_Model;
using System.Net.Http.Json;

namespace Client_Library.ClientRepository
{
    public class RecipeClientRepository : ClientRepository<RecipeCto>, IRecipeClientRepository
    {
        public RecipeClientRepository(string baseAddress) : base(baseAddress) { }

        public IEnumerable<RecipeCto> MakeableCache { get; private set; }

        public async Task<IEnumerable<RecipeCto>> GetMakeableAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetMakeable?userId={userId}");
            response.EnsureSuccessStatusCode();
            MakeableCache = await response.Content.ReadFromJsonAsync<IEnumerable<RecipeCto>>();
            return MakeableCache;
        }
    }
}
