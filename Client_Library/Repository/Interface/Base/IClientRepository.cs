using Client_Model.GraphQL.Response;

namespace Client_Library.Repository.Interface.Base
{
    public interface IClientRepository<T> where T : class
    {
        //dotnet graphql init https://localhost:7001/graphql
        //dotnet graphql update
        public T CachedItem { get; }
        public IEnumerable<T> CachedItems { get; }
        public Task<T> CreateAsync(T cto, string nodeItems);
        public Task<T> UpdateAsync(T cto, string nodeItems);
        public Task<T> DeleteAsync(int id, string nodeItems);
        public Task<T> GetAsync(int id, string nodeItems);
        public Task<(IEnumerable<T>, PageInfo)> GetAllAsync(
            string pagination,
            string filter,
            string sort,
            string nodeItems,
            string pageInfoItems);
    }
}
