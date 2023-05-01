using Microsoft.EntityFrameworkCore;
using MyFridge_Interface_GraphQL.Service.Data.Interface;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataRepository.Interface.Base;

namespace MyFridge_Interface_GraphQL.Service.Data.Abstract
{
    public abstract class DataService<T> : IDataService<T> where T : class
    {
        protected readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        protected readonly ILogger _log;
        public IDataRepository<T>? Repository { get; protected set; }

        protected DataService(IDbContextFactory<ApplicationDbContext> contextFactory, ILoggerFactory logFactory)
        {
            _contextFactory = contextFactory;
            _log = logFactory.CreateLogger("logs");

            ApplicationDbContextSeeder.Seed(_contextFactory.CreateDbContext());
        }

        public async Task CompleteAsync()
        {
            await _contextFactory.CreateDbContext().SaveChangesAsync();
        }
    }
}
