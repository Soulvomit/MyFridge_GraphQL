using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Interface.Service.Mapper.UoW.Interface;
using Data_Model;

namespace Data_Interface.Service.Mapper.UoW
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
