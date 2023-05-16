using Client_Model.Model;
using Data_Interface.Mutation.Base;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Library.DataContext;
using Data_Model;
using Data_Model.Enum;
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
            if (cto == null) return null;

            cto.Id = default;
            AddressDto? dto = _map.Address.ToDto(from: cto);

            if (dto == null) return null;

            await context.Addresses.AddAsync(dto);

            await context.SaveChangesAsync();
            return _map.Address.ToCto(from: dto);
        }
        public async Task<AddressCto?> UpdateAddressAsync(ApplicationDbContext context, AddressCto cto)
        {
            if (cto == null) return null;

            AddressDto? dto = _map.Address.ToDto(from: cto);

            if (dto == null) return null;

            context.Addresses.Update(dto);

            await context.SaveChangesAsync();
            return _map.Address.ToCto(from: dto);
        }
        public async Task<bool> DeleteAddressAsync(ApplicationDbContext context, AddressCto cto)
        {
            if (cto == null) return false;

            AddressDto? dto = await context.Addresses.FindAsync(cto.Id);

            if (dto == null) return false;

            context.Addresses.Remove(dto);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<AddressCto?> ChangeAddressCoreAsync(ApplicationDbContext context, AddressCto cto)
        {
            if (cto == null) return null;

            AddressDto? dto = await context.Addresses.FindAsync(cto.Id);

            if (dto == null) return null;

            dto.Street = cto.Street;
            dto.Extension = cto.Extension;
            dto.City = cto.City;
            dto.State = cto.State;
            dto.ZipCode = cto.ZipCode;
            dto.Country = (ECountry)cto.Country;

            await context.SaveChangesAsync();
            return _map.Address.ToCto(dto);
        }
    }
}