using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Data.DataModel.Enum;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_WebAPI.Service.Mapper.Interface;

namespace MyFridge_Interface_WebAPI.Service.Mapper
{
    public class MapperService: IMapperService
    {
        #region Address
        public AddressCto? ToAddressCto(AddressDto? from)
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
        public AddressDto? ToAddressDto(AddressCto? from)
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
        #endregion

        #region AdminAccount
        public AdminAccountCto? ToAdminAccountCto(AdminAccountDto? from)
        {
            if (from == null) return null;

            AdminAccountCto cto = new()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Password = from.Password,
                EmployeeNumber = from.EmployeeNumber
            };

            return cto;
        }
        public AdminAccountDto? ToAdminAccountDto(AdminAccountCto? from)
        {
            if (from == null) return null;

            AdminAccountDto dto = new()
            {
                Id = from.Id,
                FirstName = from.FirstName,
                LastName = from.LastName,
                Password = from.Password,
                EmployeeNumber = from.EmployeeNumber
            };

            return dto;
        }
        #endregion

        #region UserAccount
        public UserAccountCto? ToUserAccountCto(UserAccountDto? from)
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
                Address = ToAddressCto(from.Address!)
            };
            foreach (OrderDto order in from.Orders)
            {
                cto.Orders.Add(ToOrderCto(from: order));
            }
            foreach (IngredientAmountDto ingredientAmount in from.IngredientAmounts)
            {
                cto.IngredientAmounts.Add(ToIngredientAmountCto(from: ingredientAmount));
            }
            return cto;
        }
        public UserAccountDto? ToUserAccountDto(UserAccountCto? from)
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
                BirthDate = from.BirthDate
            };
            foreach (OrderCto cto in from.Orders)
            {
                dto.Orders.Add(ToOrderDto(from: cto));
            }
            foreach (IngredientAmountCto cto in from.IngredientAmounts)
            {
                dto.IngredientAmounts.Add(ToIngredientAmountDto(from: cto));
            }
            return dto;
        }
        #endregion

        #region Grocery
        public GroceryCto? ToGroceryCto(GroceryDto? from)
        {
            if (from == null) return null;

            GroceryCto cto = new()
            {
                Id = from.Id,
                Brand = from.Brand,
                SalePrice = from.SalePrice,
                ItemIdentifier = from.ItemIdentifier,
                ImageUrl = from.ImageUrl,
                IngredientAmount = ToIngredientAmountCto(from.IngredientAmount)
            };
            return cto;
        }
        public GroceryDto? ToGroceryDto(GroceryCto? from)
        {
            if (from == null) return null;

            GroceryDto dto = new()
            {
                Id = from.Id,
                Brand = from.Brand,
                SalePrice = from.SalePrice,
                ItemIdentifier = from.ItemIdentifier,
                ImageUrl = from.ImageUrl,
                IngredientAmount = ToIngredientAmountDto(from.IngredientAmount)
            };

            return dto;
        }
        #endregion

        #region Ingredient
        public IngredientCto? ToIngredientCto(IngredientDto? from)
        {
            if (from == null) return null;

            IngredientCto cto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Unit = (int)from.Unit,
                Category = from.Category
            };

            return cto;
        }
        public IngredientDto? ToIngredientDto(IngredientCto? from)
        {
            if (from == null) return null;

            IngredientDto dto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Unit = (EUnit)from.Unit,
                Category = from.Category,
            };

            return dto;
        }
        #endregion

        #region IngredientAmount
        public IngredientAmountCto? ToIngredientAmountCto(IngredientAmountDto? from)
        {
            if (from == null) return null;

            IngredientAmountCto cto = new()
            {
                Id = from.Id,
                Ingredient = ToIngredientCto(from.Ingredient),
                Amount = from.Amount,
                ExpirationDate = from.ExpirationDate
            };

            return cto;
        }
        public IngredientAmountDto? ToIngredientAmountDto(IngredientAmountCto? from)
        {
            if (from == null) return null;

            IngredientAmountDto dto = new()
            {
                Id = from.Id,
                Ingredient = ToIngredientDto(from.Ingredient),
                Amount = from.Amount,
                ExpirationDate = from.ExpirationDate
            };

            return dto;
        }
        #endregion

        #region Order
        public OrderCto? ToOrderCto(OrderDto? from)
        {
            if (from == null) return null;

            OrderCto cto = new()
            {
                Id = from.Id,
                Created = from.CreationTime,
                Status = (int)from.Status
            };
            foreach (GroceryDto dto in from.Groceries)
            {
                cto.Groceries.Add(ToGroceryCto(from: dto));
            }

            return cto;
        }
        public OrderDto? ToOrderDto(OrderCto? from)
        {
            if (from == null) return null;

            OrderDto dto = new()
            {
                Id = from.Id,
                Status = (EOrderStatus)from.Status
            };
            foreach (GroceryCto cto in from.Groceries)
            {
                dto.Groceries.Add(ToGroceryDto(from: cto));
            }

            return dto;
        }
        #endregion

        #region Recipy
        public RecipeCto? ToRecipeCto(RecipeDto? from)
        {
            if (from == null) return null;

            RecipeCto cto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Method = from.Method,
                ImageUrl = from.ImageUrl
            };
            foreach (IngredientAmountDto dto in from.IngredientAmounts)
            {
                cto.IngredientAmounts.Add(ToIngredientAmountCto(from: dto));
            }

            return cto;
        }
        public RecipeDto? ToRecipeDto(RecipeCto? from)
        {
            if (from == null) return null;

            RecipeDto dto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Method = from.Method,
                ImageUrl = from.ImageUrl
            };

            foreach (IngredientAmountCto cto in from.IngredientAmounts)
            {
                dto.IngredientAmounts.Add(ToIngredientAmountDto(from: cto));
            }

            return dto;
        }
        #endregion
    }
}
