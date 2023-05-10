using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;
using System.Linq.Expressions;

namespace Data_Interface.Service.Mapper
{
    public class AddressMapper: IMapperService<AddressDto, AddressCto>
    {
        public AddressCto? ToCto(AddressDto? from)
        {
            if (from == null) return null;

            AddressCto cto = new()
            {
                Id = from.Id,
                Street = from.Street,
                Extension = from.Extension,
                City = from.City,
                State = from.State,
                ZipCode = from.ZipCode,
                Country = (int)from.Country
            };

            return cto;
        }
        public AddressDto? ToDto(AddressCto? from)
        {
            if (from == null) return null;

            AddressDto dto = new()
            {
                Id = from.Id,
                Street = from.Street,
                Extension = from.Extension,
                City = from.City,
                State = from.State,
                ZipCode = from.ZipCode,
                Country = (ECountry)from.Country
            };

            return dto;
        }

        public Expression<Func<AddressDto, AddressCto>> ProjectToCto()
        {
            return dto => new AddressCto()
            {
                Id = dto.Id,
                Street = dto.Street,
                Extension = dto.Extension,
                City = dto.City,
                State = dto.State,
                ZipCode = dto.ZipCode,
                Country = (int)dto.Country
            };
        }

        public Expression<Func<AddressCto, AddressDto>> ProjectToDto()
        {
            return dto => new AddressDto()
            {
                Id = dto.Id,
                Street = dto.Street,
                Extension = dto.Extension,
                City = dto.City,
                State = dto.State,
                ZipCode = dto.ZipCode,
                Country = (ECountry)dto.Country
            };
        }
    }
}
