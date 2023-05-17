using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model;
using Client_Model.GraphQL;
using Client_Model.GraphQL.Response;
using Client_Model.Model;
using System.Net.Http.Json;

namespace Client_Library.Repository
{
    public class RecipeClientRepository : ClientRepository<RecipeCto>, IRecipeClientRepository
    {
        public RecipeClientRepository(string baseAddress) : base(baseAddress) { }

        public IEnumerable<RecipeCto> CachedMakeableItems { get; private set; }

        public async Task<(IEnumerable<RecipeCto>, PageInfo)> GetMakeableAsync(
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
                makeable{{ResolvePluralName.ToLower()}} ({{pagination}} {{filter}} {{sort}}) 
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
                .ReadFromJsonAsync<GraphQLResponse<Dictionary<string, CollectionResponse<Edge<RecipeCto>, RecipeCto>>>>();

            IEnumerable<RecipeCto> ctos = graphQLResponse.Data[$"makeable{ResolvePluralName.ToLower()}"].Nodes;

            PageInfo pageInfo = graphQLResponse.Data[$"makeable{ResolvePluralName.ToLower()}"].PageInfo;

            return (ctos, pageInfo);
        }
    }
}
