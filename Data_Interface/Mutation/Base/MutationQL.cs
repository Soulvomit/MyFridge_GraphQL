using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation.Base
{
    public abstract class MutationQL
    {
        protected readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        protected readonly IMapperUoW _map;
        protected readonly ILogger<MutationQL> _log;
        protected MutationQL(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<MutationQL> log)
        {
            _dbContextFactory = dbContextFactory;
            _map = map;
            _log = log;

            using ApplicationDbContext context = _dbContextFactory.CreateDbContext();
            ApplicationDbContextSeeder.Seed(context);
        }
    }
}
