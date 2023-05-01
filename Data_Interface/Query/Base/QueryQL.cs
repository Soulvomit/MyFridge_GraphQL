using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query.Base
{
    public abstract class QueryQL
    {
        protected readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        protected readonly IMapperUoW _map;
        protected readonly ILogger<QueryQL> _log;
        protected QueryQL(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<QueryQL> log)
        {
            _dbContextFactory = dbContextFactory;
            _map = map;
            _log = log;

            using ApplicationDbContext context = _dbContextFactory.CreateDbContext();
            ApplicationDbContextSeeder.Seed(context);
        }
    }
}
