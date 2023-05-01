using Client_Library.Interface.Base;
using Client_Model;
using System.Net.Http.Json;

namespace Client_Library.Abstract
{
    public abstract class ClientRepository<T> : IClientRepository<T> where T : class
    {
        protected readonly HttpClient _httpClient;
        public string ResolveName
        {
            get
            {
                string resolver = typeof(T).Name;

                string result = resolver switch
                {
                    nameof(AddressCto) => "Address",
                    nameof(AdminAccountCto) => "AdminAccount",
                    nameof(GroceryCto) => "Grocery",
                    nameof(IngredientAmountCto) => "IngredientAmount",
                    nameof(IngredientCto) => "Ingredient",
                    nameof(OrderCto) => "Order",
                    nameof(RecipeCto) => "Recipe",
                    nameof(UserAccountCto) => "UserAccount",
                    _ => throw new ArgumentException($"Unsupported type '{resolver}'.")
                };

                return result;
            }
        }
        public virtual T CachedItem { get; protected set; }
        public virtual IEnumerable<T> AllCache { get; protected set; }
        public virtual IEnumerable<T> FilteredCache { get; protected set; }
        public ClientRepository(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);
        }
        public virtual async Task<T> UpsertAsync(T dto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/{ResolveName}/Upsert", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public virtual async Task<T> GetAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/Get?id={id}");
            response.EnsureSuccessStatusCode();
            CachedItem = await response.Content.ReadFromJsonAsync<T>();
            return CachedItem;
        }
        public virtual async Task<IEnumerable<T>> GetFilteredAsync(string filter)
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetFiltered?filter={filter}");
            response.EnsureSuccessStatusCode();
            FilteredCache = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
            return FilteredCache;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetAll");
            response.EnsureSuccessStatusCode();
            AllCache = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
            return AllCache;
        }
        public virtual async Task<T> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/{ResolveName}/Get?id={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
