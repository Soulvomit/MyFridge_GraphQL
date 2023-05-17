using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model;
using Client_Model.GraphQL;
using Client_Model.Model;
using System.Net.Http.Json;

namespace Client_Library.Repository
{
    public class UserAccountClientRepository : ClientRepository<UserAccountCto>, IUserAccountClientRepository
    {
        public UserAccountClientRepository(string baseAddress) : base(baseAddress) { }

        public async Task<UserAccountCto> ChangeAsync(UserAccountCto cto, string nodeItems, bool core = false)
        {
            if (core)
            {
                return await base.ChangeAsync(cto, nodeItems);
            }
            string ctoStr = cto.SerializeToUpdateInputType();

            string mutation = FormatHelper.FormatMutation(
            $$"""
            mutation
            { 
                change{{ResolveName}} (cto: {{ctoStr}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, UserAccountCto>>>();

            UserAccountCto responseCto = graphQLResponse.Data[$"change{ResolveName}"];
            return responseCto;
        }

        public async Task<UserAccountCto> GetByEmailAsync(string email, string nodeItems)
        {
            string query = FormatHelper.FormatQuery(
            $$"""
            query
            { 
                {{ResolveName.ToLower()}}ByEmail (cto: { email: {{email}} }) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(query, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, UserAccountCto>>>();

            UserAccountCto cto = graphQLResponse.Data[$"{ResolveName.ToLower()}ByEmail"];
            return cto;
        }

        public async Task<UserAccountCto> AddIngredientAmountAsync(UserAccountCto cto, IngredientAmountCto ingredientAmountCto, string nodeItems, bool newBatch = false)
        {
            string ctoStr = cto.SerializeToUpdateInputType();
            string iaCtoStr = ingredientAmountCto.SerializeToUpdateInputType();

            string mutation = FormatHelper.FormatMutation(
            $$"""
            mutation
            { 
                addAmount{{ResolveName}} (cto: {{ctoStr}} ingredientAmountCto: {{iaCtoStr}} newBatch: {{newBatch}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, UserAccountCto>>>();

            UserAccountCto responseCto = graphQLResponse.Data[$"addAmount{ResolveName}"];
            return responseCto;
        }

        public async Task<bool> RemoveIngredientAmountAsync(UserAccountCto cto, IngredientAmountCto ingredientAmountCto, string nodeItems)
        {
            string ctoStr = cto.SerializeToUpdateInputType();
            string iaCtoStr = ingredientAmountCto.SerializeToUpdateInputType();

            string mutation = FormatHelper.FormatMutation(
            $$"""
            mutation
            { 
                removeAmount{{ResolveName}} (cto: {{ctoStr}} ingredientAmountCto: {{iaCtoStr}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PostAsync("", content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, bool>>>();

            bool responseCto = graphQLResponse.Data[$"removeAmount{ResolveName}"];
            return responseCto;
        }
    }
}