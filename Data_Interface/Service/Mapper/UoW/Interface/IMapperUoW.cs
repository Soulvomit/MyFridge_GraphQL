using Client_Model.Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;

namespace Data_Interface.Service.Mapper.UoW.Interface
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
