using MyFridge_Interface_GraphQL.Service.Mapper.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataModel.Enum;

namespace MyFridge_Interface_GraphQL.Service.Mapper
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
    }
}
