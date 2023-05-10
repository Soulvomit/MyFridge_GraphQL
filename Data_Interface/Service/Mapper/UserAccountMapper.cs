using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;
using System.Linq.Expressions;

namespace Data_Interface.Service.Mapper
{
    public class UserAccountMapper : IMapperService<UserAccountDto, UserAccountCto>
    {
        private readonly AddressMapper _mapAddress = new();
        private readonly OrderMapper _mapOrder = new();
        private readonly IngredientAmountMapper _mapIngredientAmount = new();

        public UserAccountCto? ToCto(UserAccountDto? from)
        {
            if (from == null) return null;

            UserAccountCto cto = new()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Password = from.Password,
                Email = from.Email,
                PhoneNumber = from.PhoneNumber.ToString(),
                BirthDate = from.BirthDate,
                Address = _mapAddress.ToCto(from.Address)
            };
            foreach (OrderDto dto in from.Orders)
            {
                cto.Orders.Add(_mapOrder.ToCto(from: dto));
            }
            foreach (IngredientAmountDto ingredientAmount in from.IngredientAmounts)
            {
                cto.IngredientAmounts.Add(_mapIngredientAmount.ToCto(from: ingredientAmount));
            }
            return cto;
        }

        public UserAccountDto? ToDto(UserAccountCto? from)
        {
            if (from == null) return null;

            UserAccountDto dto = new()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Password = from.Password,
                Email = from.Email,
                PhoneNumber = ulong.Parse(from.PhoneNumber),
                BirthDate = from.BirthDate ?? default,
                Address = _mapAddress.ToDto(from.Address)
            };
            foreach (OrderCto cto in from.Orders)
            {
                dto.Orders.Add(_mapOrder.ToDto(from: cto));
            }
            foreach (IngredientAmountCto cto in from.IngredientAmounts)
            {
                dto.IngredientAmounts.Add(_mapIngredientAmount.ToDto(from: cto));
            }
            return dto;
        }
        public Expression<Func<UserAccountDto, UserAccountCto>> ProjectToCto()
        {
            var mappingExpression = _mapIngredientAmount.ProjectToCto();
            var mappingExpression2 = _mapOrder.ProjectToCto();
            return dto => new UserAccountCto()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Password = dto.Password,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber.ToString(),
                BirthDate = dto.BirthDate,
                Address = new AddressCto()
                {
                    Id = dto.Address.Id,
                    City = dto.Address.City,
                    Country = (int)dto.Address.Country,
                    Extension = dto.Address.Extension,
                    State = dto.Address.State,
                    Street = dto.Address.Street,
                    ZipCode = dto.Address.ZipCode,
                },
                IngredientAmounts = dto.IngredientAmounts.AsQueryable().Select(mappingExpression).ToList(),
                Orders = dto.Orders.AsQueryable().Select(mappingExpression2).ToList()
            };
        }

        public Expression<Func<UserAccountCto, UserAccountDto>> ProjectToDto()
        {
            var mappingExpression = _mapIngredientAmount.ProjectToDto();
            var mappingExpression2 = _mapOrder.ProjectToDto();
            return cto => new UserAccountDto()
            {
                Id = cto.Id,
                FirstName = cto.FirstName,
                LastName = cto.LastName,
                Password = cto.Password,
                Email = cto.Email,
                PhoneNumber = ulong.Parse(cto.PhoneNumber),
                BirthDate = cto.BirthDate ?? default,
                Address = new AddressDto()
                {
                    Id = cto.Address.Id,
                    City = cto.Address.City,
                    Country = (ECountry)cto.Address.Country,
                    Extension = cto.Address.Extension,
                    State = cto.Address.State,
                    Street = cto.Address.Street,
                    ZipCode = cto.Address.ZipCode,
                },
                IngredientAmounts = cto.IngredientAmounts.AsQueryable().Select(mappingExpression).ToList(),
                Orders = cto.Orders.AsQueryable().Select(mappingExpression2).ToList()
            };
        }
    }
}
