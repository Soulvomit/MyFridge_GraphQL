using Client_Model.GraphQL;
using Client_Model.GraphQL.Response;
using Client_Model.Model;
using System.Net.Http.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace Client_TestConsole
{
    class Program
    {
        private static string FormatNullableOutput(string nullable)
        {
            if (nullable != "null")
            {
                nullable = $$"""
                            \"{{nullable}}\"
                            """;
            }

            return nullable;
        }
        private static string FormatNullableInput(object? nullable)
        {
            if (nullable != null)
            {
                return $$"""
                            \"{{nullable}}\"
                            """;
            }

            return "null";
        }
        private static string FormatPagination(int entries, string cursor = "null")
        {
            if (entries == -1)
                return string.Empty;

            cursor = FormatNullableOutput(cursor);

            return $$"""
                    first: {{entries}} after: {{cursor}}
                    """;
        }
        private static string FormatFilter(string condition)
        {
            if (string.IsNullOrEmpty(condition)) 
                return string.Empty;

            return $$"""
                    where: {{{condition}}}
                    """;
        }
        private static string FormatOrder(string order)
        {
            if (string.IsNullOrEmpty(order))
                return string.Empty;

            return $$"""
                    order: {{{order}}}
                    """;
        }
        private static string FormatItems(params string[] items)
        {
            StringBuilder itemBuilder = new();
            foreach (string item in items)
            {
                itemBuilder.Append(item).Append(' ');
            }
            return itemBuilder.ToString();
        }
        private static string FormatQuery(string query)
        {
            query = $$"""
                    {
                        "query": 
                        "
                        {{query}}
                        " 
                    }
                    """;

            string trimmedQuery = Regex.Replace(query, @"(\s+|\r\n)\s*", " ");
            return trimmedQuery.Replace("( )", "");
        }

        private static string FormatMutation(string mutation)
        {
            mutation = $$"""
                    {
                        "query": 
                        "
                        {{mutation}}
                        " 
                    }
                    """;

            string trimmedQuery = Regex.Replace(mutation, @"(\s+|\r\n)\s*", " ");
            return trimmedQuery;
        }
        private static string PascalToCamel(string pascalStr) 
        {
            return char.ToLower(pascalStr[0]) + pascalStr.Substring(1);
        }

        static async Task Main(string[] args)
        {
            //AddressCto cto = await GetAsync(2);
            //Console.WriteLine($"Address {cto.Id} at street: {cto.Street}");

            //(List<AddressCto>, PageInfo) ctos = await GetAllAsync(
            //    FormatPagination(1), 
            //    FormatFilter($$"""
            //                 country: {eq: 46}
            //                 """), 
            //    FormatOrder($$"""
            //                state:ASC
            //                """), 
            //    FormatItems("id", "street", "extension", "city", "state", "zipCode", "country"),
            //    FormatItems("endCursor", "hasNextPage"));

            //(List<AddressCto>, PageInfo) ctos1 = await GetAllAsync(
            //    FormatPagination(1, ctos.Item2.EndCursor),
            //    FormatFilter($$"""
            //                 country: {eq: 46}
            //                 """),
            //    FormatOrder($$"""
            //                state:ASC
            //                """),
            //    FormatItems("id", "street", "extension", "city", "state", "zipCode", "country"),
            //    FormatItems("endCursor"));

            AddressCto cto = await CreateAsync(
                new AddressCto { Street = "aaa", Extension = "bbb", City = "ccc", State = "ddd", ZipCode = "eee", Country = 1 }, 
                FormatItems("id", "street", "extension", "city", "state", "zipCode", "country"));

        }

        private static async Task<AddressCto> GetAsync(int id, string nodeItems)
        {
            using HttpClient httpClient = new();
            Uri uri = new("https://localhost:7001/graphql");

            string query = FormatQuery($$"""
                                        query
                                        { 
                                            address (cto: { id: {{id}} }) 
                                            { 
                                                {{nodeItems}}
                                            } 
                                        }
                                        """);

            StringContent content = new(query, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            response.EnsureSuccessStatusCode();

            GraphQLResponse<Dictionary<string, AddressCto>>? graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, AddressCto>>>();

            AddressCto? addressCto = graphQLResponse.Data["address"];
            return addressCto;
        }
        private static async Task<(List<AddressCto>, PageInfo)> GetAllAsync(
            string pagination, 
            string filter, 
            string sort, 
            string nodeItems,
            string pageInfoItems)
        {
            using HttpClient httpClient = new();
            Uri uri = new("https://localhost:7001/graphql");

            string query = FormatQuery($$"""
                                        query
                                        { 
                                            addresses({{pagination}} {{filter}} {{sort}}) 
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

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse = await response.Content
                .ReadFromJsonAsync<GraphQLResponse<Dictionary<string, CollectionResponse<Edge<AddressCto>, AddressCto>>>>();

            List<AddressCto>? addressCtos = graphQLResponse.Data["addresses"].Nodes.ToList();

            PageInfo pageInfo = graphQLResponse.Data["addresses"].PageInfo;

            return (addressCtos, pageInfo);
        }
        private static async Task<AddressCto> CreateAsync(AddressCto cto, string nodeItems)
        {
            using HttpClient httpClient = new();
            Uri uri = new("https://localhost:7001/graphql");

            string input = $$"""
                            {
                             {{PascalToCamel(nameof(cto.Street))}}:{{FormatNullableInput(cto.Street)}}
                             {{PascalToCamel(nameof(cto.Extension))}}:{{FormatNullableInput(cto.Extension)}}
                             {{PascalToCamel(nameof(cto.City))}}:{{FormatNullableInput(cto.City)}}
                             {{PascalToCamel(nameof(cto.State))}}:{{FormatNullableInput(cto.State)}}
                             {{PascalToCamel(nameof(cto.ZipCode))}}:{{FormatNullableInput(cto.ZipCode)}}
                             {{PascalToCamel(nameof(cto.Country))}}:{{cto.Country}}
                            }
                            """;

            string mutation = FormatMutation(
            $$"""
            mutation
            { 
                createAddress (cto: {{input}}) 
                { 
                    {{nodeItems}}
                } 
            }
            """);

            StringContent content = new(mutation, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            response.EnsureSuccessStatusCode();

            var graphQLResponse
                = await response.Content.ReadFromJsonAsync<GraphQLResponse<Dictionary<string, AddressCto>>>();

            AddressCto responseCto = graphQLResponse.Data["createAddress"];
            return responseCto;
        }
    }
}