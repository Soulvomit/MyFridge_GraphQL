namespace Client_Model.GraphQL.Response
{
    public class Edge<T> where T : class
    {
        public T Node { get; set; }
        public string Cursor { get; set; }
    }
}
