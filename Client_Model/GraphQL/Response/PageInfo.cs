namespace Client_Model.GraphQL.Response
{
    public class PageInfo
    {
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string StartCursor { get; set; }
        public string EndCursor { get; set; }
    }
}
