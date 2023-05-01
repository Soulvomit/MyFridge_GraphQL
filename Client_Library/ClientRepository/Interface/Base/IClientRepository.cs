namespace Client_Library.Interface.Base
{
    public interface IClientRepository<T> where T : class
    {
        public T CachedItem { get; }
        public IEnumerable<T> AllCache { get; }
        public IEnumerable<T> FilteredCache { get; }
        public Task<T> UpsertAsync(T dto);
        public Task<T> GetAsync(int id);
        public Task<IEnumerable<T>> GetFilteredAsync(string filter);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> DeleteAsync(int id);
    }
}
