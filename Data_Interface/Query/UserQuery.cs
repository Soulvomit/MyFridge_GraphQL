using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class UserQuery : QueryQL
    {
        public UserQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            IMapperUoW map,
            ILogger<UserQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<UserAccountCto?> GetUserAsync(UserAccountCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            UserAccountDto? dto = await context.Users.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.User.ToCto(from: dto);
        }
        public async Task<UserAccountCto?> GetUserByEmailAsync(UserAccountCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            UserAccountDto? dto = await context.Users.FirstOrDefaultAsync(c => c.Email == cto.Email);

            if (dto == null) return null;

            return _map.User.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<UserAccountCto?> GetUsers(ApplicationDbContext context)
        {
            IQueryable<UserAccountCto?> ctos = context.Users.Select(dto => _map.User.ToCto(dto));

            return ctos;
        }
    }
}