using MyFridge_Library_Data.DataRepository.Interface.Base;

namespace MyFridge_Interface_GraphQL.Service.Data.Interface
{
    public interface IDataService<T> where T : class
    {
        public IDataRepository<T>? Repository { get; }

        Task CompleteAsync();
    }
}
