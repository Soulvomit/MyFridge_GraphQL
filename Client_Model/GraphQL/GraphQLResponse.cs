using Client_Model.GraphQL.Error;

namespace Client_Model.GraphQL
{
    public class GraphQLResponse<T>
    {
        public T Data { get; set; }
        public List<GraphQLError> Errors { get; set; }
    }
}
