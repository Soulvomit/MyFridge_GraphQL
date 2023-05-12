namespace Client_Model.GraphQL.Response
{
    public class CollectionResponse<E, N> where E : class where N : class
    {
        public IEnumerable<N> Nodes { get; set; }
        public List<E> Edges { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
