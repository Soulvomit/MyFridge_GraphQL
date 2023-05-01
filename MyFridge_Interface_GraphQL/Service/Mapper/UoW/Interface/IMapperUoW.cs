using MyFridge_Interface_GraphQL.Service.Mapper.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Service.Mapper.UoW.Interface
{
    public interface IMapperUoW
    {
        public IMapperService<AddressDto, AddressCto> Address { get; }
        public IMapperService<AdminAccountDto, AdminAccountCto> Admin { get; }
        public IMapperService<GroceryDto, GroceryCto> Grocery { get; }
        public IMapperService<IngredientAmountDto, IngredientAmountCto> IngredientAmount { get;  }
        public IMapperService<IngredientDto, IngredientCto> Ingredient { get;  }
        public IMapperService<OrderDto, OrderCto> Order { get;  }
        public IMapperService<RecipeDto, RecipeCto> Recipe { get; }
        public IMapperService<UserAccountDto, UserAccountCto> User { get; }
    }
}
