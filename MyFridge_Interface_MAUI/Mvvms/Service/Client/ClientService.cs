﻿using MyFridge_Library_Client_MAUI.ClientRepository;
using MyFridge_Library_Client_MAUI.ClientRepository.Interface;
using MyFridge_Interface_MAUI.Mvvms.Service.Client.Interface;

namespace MyFridge_Interface_MAUI.Mvvms.Service.Client
{
    public class ClientService : IClientService, IDisposable, IAsyncDisposable
    {
        private readonly string baseAddress = "https://localhost:44364/";
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

        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
