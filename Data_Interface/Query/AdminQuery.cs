using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class AdminQuery : QueryQL
    {
        public AdminQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<AdminQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<AdminAccountCto?> GetAdminAsync(AdminAccountCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            AdminAccountDto? dto = await context.Admins.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.Admin.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AdminAccountCto?> GetAdmins(ApplicationDbContext context)
        {
            IQueryable<AdminAccountCto?> ctos = context.Admins.Select(dto => _map.Admin.ToCto(dto));

            return ctos;
        }
    }
}
