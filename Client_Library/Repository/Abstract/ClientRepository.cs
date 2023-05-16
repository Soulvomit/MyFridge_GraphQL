using Client_Library.Repository.Interface.Base;
using Client_Model;
using Client_Model.GraphQL;
using Client_Model.GraphQL.Response;
using Client_Model.Model;
using Client_Model.Model.Interface;
using System.Net.Http.Json;
using System.Text.Json;

namespace Client_Library.Repository.Abstract
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
                    nameof(AdminAccountCto) => "Admin",
                    nameof(GroceryCto) => "Grocery",
                    nameof(IngredientAmountCto) => "IngredientAmount",
                    nameof(IngredientCto) => "Ingredient",
                    nameof(OrderCto) => "Order",
                    nameof(RecipeCto) => "Recipe",
                    nameof(UserAccountCto) => "User",
                    _ => throw new ArgumentException($"Unsupported type '{resolver}'.")
                };

                return result;
            }
        }
        public string ResolvePluralName
        {
            get
            {
                string resolver = typeof(T).Name;

                string result = resolver switch
                {
                    nameof(AddressCto) => "Addresses",
                    nameof(AdminAccountCto) => "Admins",
                    nameof(GroceryCto) => "Groceries",
                    nameof(IngredientAmountCto) => "IngredientAmounts",
                    nameof(IngredientCto) => "Ingredients",
                    nameof(OrderCto) => "Orders",
                    nameof(RecipeCto) => "Recipes",
                    nameof(UserAccountCto) => "Users",
                    _ => throw new ArgumentException($"Unsupported type '{resolver}'.")
                };

                return result;
            }
        }
        public virtual T CachedItem { get; protected set; }
        public virtual IEnumerable<T> CachedItems { get; protected set; }

        T IClientRepository<T>.CachedItem => throw new NotImplementedException();

        IEnumerable<T> IClientRepository<T>.CachedItems => throw new NotImplementedException();

        protected ClientRepository(string baseAddress)
        {
            //Uri uri = new("https://localhost:7001/graphql");
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }
        public virtual async Task<T> CreateAsync(T cto, string nodeItems)
        {
            string ctoStr = (cto as ICto).SerializeToCreateInputType();

            string mutation = FormatHelper.FormatMutation(
            $$"""
            mutation
            { 
                create{{ResolveName}} (cto: {{ctoStr}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, T>>>();

            T responseCto = graphQLResponse.Data[$"create{ResolveName}"];
            return responseCto;
        }
        public virtual async Task<T> UpdateAsync(T cto, string nodeItems)
        {
            string ctoStr = (cto as ICto).SerializeToUpdateInputType();

            string mutation = FormatHelper.FormatMutation(
            $$"""
            mutation
            { 
                update{{ResolveName}} (cto: {{ctoStr}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, T>>>();

            T responseCto = graphQLResponse.Data[$"update{ResolveName}"];
            return responseCto;
        }
        public virtual async Task<T> ChangeAsync(T cto, string nodeItems)
        {
            string ctoStr = (cto as ICto).SerializeToUpdateInputType();

            string mutation = FormatHelper.FormatMutation(
            $$"""
            mutation
            { 
                change{{ResolveName}}Core (cto: {{ctoStr}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, T>>>();

            T responseCto = graphQLResponse.Data[$"update{ResolveName}"];
            return responseCto;
        }
        public virtual async Task<T> DeleteAsync(int id, string nodeItems)
        {
            string mutation = FormatHelper.FormatMutation(
            $$"""
            mutation
            { 
                delete{{ResolveName}} (id: {{id}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, T>>>();

            T cto = graphQLResponse.Data[$"delete{ResolveName}"];
            return cto;
        }
        public virtual async Task<T> GetAsync(int id, string nodeItems)
        {
            string query = FormatHelper.FormatQuery(
            $$"""
            query
            { 
                {{ResolveName.ToLower()}} (cto: { id: {{id}} }) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(query, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, T>>>();

            T cto = graphQLResponse.Data[ResolveName.ToLower()];
            return cto;
        }
        public virtual async Task<(IEnumerable<T>, PageInfo)> GetAllAsync(
            string pagination,
            string filter,
            string sort,
            string nodeItems,
            string pageInfoItems)
        {
            string query = FormatHelper.FormatQuery(
            $$"""
            query
            { 
                {{ResolvePluralName.ToLower()}} ({{pagination}} {{filter}} {{sort}}) 
                { 
                    nodes
                    {
                        {{nodeItems}}
                    } 
                    pageInfo 
                    { 
                        {{pageInfoItems}}
                    } 
                } 
            }
            """);

            StringContent content = new(query, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse = await response.Content
                .ReadFromJsonAsync<GraphQLResponse<Dictionary<string, CollectionResponse<Edge<T>, T>>>>();

            IEnumerable<T> ctos = graphQLResponse.Data[ResolvePluralName.ToLower()].Nodes;

            PageInfo pageInfo = graphQLResponse.Data[ResolvePluralName.ToLower()].PageInfo;

            return (ctos, pageInfo);
        }
    }
}
