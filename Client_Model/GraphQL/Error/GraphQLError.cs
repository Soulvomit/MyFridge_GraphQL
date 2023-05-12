namespace Client_Model.GraphQL.Error
{
    public class GraphQLError
    {
        public string Message { get; set; }
        public List<GraphQLLocation> Locations { get; set; }
    }
}
