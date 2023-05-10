using Client_Model;
using Data_Interface.Query.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Query
{
    [ExtendObjectType<QueryQL>]
    public class AddressQuery : QueryQL
    {
        public AddressQuery(
            IDbContextFactory<ApplicationDbContext> dbContextFactory, 
            IMapperUoW map, 
            ILogger<AddressQuery> log) : base(dbContextFactory, map, log)
        {
        }

        public async Task<AddressCto?> GetAddressAsync(AddressCto cto)
        {
            await using ApplicationDbContext context = await _dbContextFactory.CreateDbContextAsync();

            AddressDto? dto = await context.Addresses.FindAsync(cto.Id);

            if (dto == null) return null;

            return _map.Address.ToCto(from: dto);
        }
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AddressCto?> GetAddresses(ApplicationDbContext context)
        {
            var mappingExpression = _map.Address.ProjectToCto();
            IQueryable<AddressCto?> ctos = context.Addresses.Select(mappingExpression);

            return ctos;
        }
    }
}
