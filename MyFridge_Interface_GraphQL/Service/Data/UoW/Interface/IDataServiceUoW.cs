using MyFridge_Interface_GraphQL.Service.Data.Interface;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Service.Data.UoW.Interface
{
    public interface IDataServiceUoW
    {
        public IDataService<AddressDto> Address { get; }
        public IDataService<AdminAccountDto> Admin { get; }
        public IDataService<GroceryDto> Grocery { get; }
        public IDataService<IngredientAmountDto> IngredientAmount { get;  }
        public IDataService<IngredientDto> Ingredient { get;  }
        public IDataService<OrderDto> Order { get;  }
        public IDataService<RecipeDto> Recipe { get; }
        public IDataService<UserAccountDto> User { get; }
    }
}
