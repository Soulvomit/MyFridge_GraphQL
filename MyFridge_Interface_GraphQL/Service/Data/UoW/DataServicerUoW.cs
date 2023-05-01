using Microsoft.EntityFrameworkCore;
using MyFridge_Interface_GraphQL.Service.Data.Interface;
using MyFridge_Interface_GraphQL.Service.Data.UoW.Interface;
using MyFridge_Library_Data.DataContext;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Service.Data.UoW
{
    public class DataServiceUoW : IDataServiceUoW
    {
        public IDataService<AddressDto> Address { get; private set; }
        public IDataService<AdminAccountDto> Admin { get; private set; }
        public IDataService<GroceryDto> Grocery { get; private set; }
        public IDataService<IngredientAmountDto> IngredientAmount { get; private set; }
        public IDataService<IngredientDto> Ingredient { get; private set; }
        public IDataService<OrderDto> Order { get; private set; }
        public IDataService<RecipeDto> Recipe { get; private set; }
        public IDataService<UserAccountDto> User { get; private set; }

        public DataServiceUoW(IDbContextFactory<ApplicationDbContext> contextFactory, ILoggerFactory logFactory)
        {

            ApplicationDbContextSeeder.Seed(contextFactory.CreateDbContext());

            Address = new AddressService(contextFactory, logFactory);
            Admin = new AdminService(contextFactory, logFactory);
            Grocery = new GroceryService(contextFactory, logFactory);
            IngredientAmount = new IngredientAmountService(contextFactory, logFactory);
            Ingredient = new IngredientService(contextFactory, logFactory);
            Order = new OrderService(contextFactory, logFactory);
            Recipe = new RecipeService(contextFactory, logFactory);
            User = new UserService(contextFactory, logFactory);
        }
    }
}
