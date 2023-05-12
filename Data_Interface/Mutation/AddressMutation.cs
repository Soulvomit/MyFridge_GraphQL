using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Interface.Mutation
{
    [ExtendObjectType<MutationQL>]
    public class AddressMutation : MutationQL
    {
        public AddressMutation(
            IDbContextFactory<ApplicationDbContext> dbContextFactory, 
            IMapperUoW map, 
            ILogger<MutationQL> log) : base(dbContextFactory, map, log)
        {
        }
        public async Task<AddressCto?> CreateAddressAsync(ApplicationDbContext context, AddressCto cto)
        {
            cto.Id = 0;
            AddressDto? dto = _map.Address.ToDto(from: cto);

            await context.Addresses.AddAsync(dto);
            await context.SaveChangesAsync();
            return _map.Address.ToCto(from: dto);
        }
        public async Task<AddressCto?> UpdateAddressAsync(ApplicationDbContext context, AddressCto cto)
        {
            AddressDto? dto = _map.Address.ToDto(from: cto);

            context.Addresses.Update(dto);
            await context.SaveChangesAsync();
            return _map.Address.ToCto(from: dto);
        }
        public async Task<bool> DeleteAddressAsync(ApplicationDbContext context, AddressCto cto)
        {
            AddressDto? dto = await context.Addresses.FindAsync(cto.Id);

            if (dto == null)
                return false;

            context.Addresses.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}