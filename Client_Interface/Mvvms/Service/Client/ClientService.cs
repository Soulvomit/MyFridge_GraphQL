using Client_Interface.Mvvms.Service.Client.Interface;
using Client_Library.ClientRepository;
using Client_Library.Interface;

namespace Client_Interface.Mvvms.Service.Client
{
    public class ClientService : IClientService, IDisposable, IAsyncDisposable
    {
        private readonly string baseAddress = "https://localhost:8001/";
        public IAddressClientRepository AddressClient { get; set; }
        public IAdminAccountClientRepository AdminClient { get; set; }
        public IUserAccountClientRepository UserClient { get; set; }
        public IIngredientClientRepository IngredientClient { get; set; }
        public IIngredientAmountClientRepository IngredientAmountClient { get; set; }
        public IGroceryClientRepository GroceryClient { get; set; }
        public IOrderClientRepository OrderClient { get; set; }
        public IRecipeClientRepository RecipeClient { get; set; }
        public ClientService()
        {
            AddressClient = new AddressClientRepository(baseAddress);
            AdminClient = new AdminAccountClientRepository(baseAddress);
            UserClient = new UserAccountClientRepository(baseAddress);
            IngredientClient = new IngredientClientRepository(baseAddress);
            IngredientAmountClient = new IngredientAmountClientRepository(baseAddress);
            GroceryClient = new GroceryClientRepository(baseAddress);
            OrderClient = new OrderClientRepository(baseAddress);
            RecipeClient = new RecipeClientRepository(baseAddress);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
