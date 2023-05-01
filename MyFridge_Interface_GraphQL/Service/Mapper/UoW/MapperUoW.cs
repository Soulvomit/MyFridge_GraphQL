using MyFridge_Interface_GraphQL.Service.Mapper.Interface;
using MyFridge_Interface_GraphQL.Service.Mapper.UoW.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Service.Mapper.UoW
{
    public class MapperUoW : IMapperUoW
    {
        public IMapperService<AddressDto, AddressCto> Address { get; private set; }
        public IMapperService<AdminAccountDto, AdminAccountCto> Admin { get; private set; }
        public IMapperService<GroceryDto, GroceryCto> Grocery { get; private set; }
        public IMapperService<IngredientAmountDto, IngredientAmountCto> IngredientAmount { get; private set; }
        public IMapperService<IngredientDto, IngredientCto> Ingredient { get; private set; }
        public IMapperService<OrderDto, OrderCto> Order { get; private set; }
        public IMapperService<RecipeDto, RecipeCto> Recipe { get; private set; }
        public IMapperService<UserAccountDto, UserAccountCto> User { get; private set; }

        public MapperUoW()
        {
            Address = new AddressMapper();
            Admin = new AdminAccountMapper();
            Grocery = new GroceryMapper();
            IngredientAmount = new IngredientAmountMapper();
            Ingredient = new IngredientMapper();
            Order = new OrderMapper();
            Recipe = new RecipeMapper();
            User = new UserAccountMapper();
        }
    }
}
