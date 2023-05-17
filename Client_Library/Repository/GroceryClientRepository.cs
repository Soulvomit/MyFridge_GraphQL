using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model;
using Client_Model.GraphQL;
using Client_Model.Model;
using System.Net.Http.Json;

namespace Client_Library.Repository
{
    public class GroceryClientRepository : ClientRepository<GroceryCto>, IGroceryClientRepository
    {
        public GroceryClientRepository(string baseAddress) : base(baseAddress) { }

        public async Task<GroceryCto> ChangeAsync(GroceryCto cto, string nodeItems, bool core = false)
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
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, GroceryCto>>>();

            GroceryCto responseCto = graphQLResponse.Data[$"change{ResolveName}"];
            return responseCto;
        }
    }
}
