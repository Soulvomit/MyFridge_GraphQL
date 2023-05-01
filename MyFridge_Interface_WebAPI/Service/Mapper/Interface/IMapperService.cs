using MyFridge_Library_Data.DataModel;
using MyFridge_Library_Client_MAUI.ClientModel;

namespace MyFridge_Interface_WebAPI.Service.Mapper.Interface
{
    public interface IMapperService
    {
        public AddressCto? ToAddressCto(AddressDto? from);
        public AddressDto? ToAddressDto(AddressCto? from);

        public AdminAccountCto? ToAdminAccountCto(AdminAccountDto? from);
        public AdminAccountDto? ToAdminAccountDto(AdminAccountCto? from);

        public UserAccountCto? ToUserAccountCto(UserAccountDto? from);
        public UserAccountDto? ToUserAccountDto(UserAccountCto? from);

        public GroceryCto? ToGroceryCto(GroceryDto? from);
        public GroceryDto? ToGroceryDto(GroceryCto? from);

        public IngredientCto? ToIngredientCto(IngredientDto? from);
        public IngredientDto? ToIngredientDto(IngredientCto? from);

        public IngredientAmountCto? ToIngredientAmountCto(IngredientAmountDto? from);
        public IngredientAmountDto? ToIngredientAmountDto(IngredientAmountCto? from);

        public OrderCto? ToOrderCto(OrderDto? from);
        public OrderDto? ToOrderDto(OrderCto? from);

        public RecipeCto? ToRecipeCto(RecipeDto? from);
        public RecipeDto? ToRecipeDto(RecipeCto? from);
    }
}
