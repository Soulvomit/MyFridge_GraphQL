using MyFridge_Library_Client_MAUI.ClientRepository.Interface.Base;
using MyFridge_Library_Client_MAUI.ClientModel;
using System.Net.Http.Json;

namespace MyFridge_Library_Client_MAUI.ClientRepository.Abstract
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
        public virtual T Lazy { get; protected set; }
        public virtual IEnumerable<T> AllLazies { get; protected set; }
        public virtual IEnumerable<T> FilteredLazies { get; protected set; }
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
            Lazy = await response.Content.ReadFromJsonAsync<T>();
            return Lazy;
        }
        public virtual async Task<IEnumerable<T>> GetFilteredAsync(string filter)
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetFiltered?filter={filter}");
            response.EnsureSuccessStatusCode();
            FilteredLazies = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
            return FilteredLazies;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync($"api/{ResolveName}/GetAll");
            response.EnsureSuccessStatusCode();
            AllLazies = await response.Content.ReadFromJsonAsync<IEnumerable<T>>();
            return AllLazies;
        }
        public virtual async Task<T> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/{ResolveName}/Get?id={id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
