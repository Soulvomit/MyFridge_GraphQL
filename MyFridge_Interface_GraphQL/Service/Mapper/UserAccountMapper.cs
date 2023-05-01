using MyFridge_Interface_GraphQL.Service.Mapper.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Service.Mapper
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
                PhoneNumber = from.PhoneNumber,
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
                PhoneNumber = from.PhoneNumber,
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
    }
}
