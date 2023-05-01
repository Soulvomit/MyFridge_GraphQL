using MyFridge_Interface_GraphQL.Service.Data.UoW.Interface;
using MyFridge_Interface_GraphQL.Service.Mapper.UoW.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Query
{
    public class QueryQL
    {
        private readonly IDataServiceUoW _service;
        private readonly IMapperUoW _map;
        private readonly ILogger _log;
        public QueryQL(IDataServiceUoW dataService, IMapperUoW map, ILogger log)
        {
            _service = dataService;
            _map = map;
            _log = log;
        }

        public async Task<AddressCto?> GetAddressAsync(AddressCto cto)
        {
            AddressDto? dto = await _service.Address.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.Address.ToCto(from: dto);
        }
        public async Task<List<AddressCto>?> GetAllAddressAsync()
        {
            List<AddressCto> ctos = new List<AddressCto>();
            List<AddressDto> dtos = await _service.Address.Repository.GetAllAsync();

            foreach (AddressDto dto in dtos)
            {
                ctos.Add(_map.Address.ToCto(from: dto));
            }

            return ctos;
        }

        public async Task<AdminAccountCto?> GetAdminAccountAsync(AdminAccountCto cto)
        {
            AdminAccountDto? dto = await _service.Admin.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.Admin.ToCto(from: dto);
        }
        public async Task<List<AdminAccountCto>?> GetAllAdminAccountsAsync()
        {
            List<AdminAccountCto> ctos = new List<AdminAccountCto>();
            List<AdminAccountDto> dtos = await _service.Admin.Repository.GetAllAsync();

            foreach (AdminAccountDto dto in dtos)
            {
                ctos.Add(_map.Admin.ToCto(from: dto));
            }

            return ctos;
        }

        public async Task<GroceryCto?> GetGroceryAsync(GroceryCto cto)
        {
            GroceryDto? dto = await _service.Grocery.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.Grocery.ToCto(from: dto);
        }
        public async Task<List<GroceryCto>?> GetAllGroceriesAsync()
        {
            List<GroceryCto> ctos = new List<GroceryCto>();
            List<GroceryDto> dtos = await _service.Grocery.Repository.GetAllAsync();

            foreach (GroceryDto dto in dtos)
            {
                ctos.Add(_map.Grocery.ToCto(from: dto));
            }

            return ctos;
        }

        public async Task<IngredientAmountCto?> GetIngredientAmountAsync(IngredientAmountCto cto)
        {
            IngredientAmountDto? dto = await _service.IngredientAmount.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.IngredientAmount.ToCto(from: dto);
        }
        public async Task<List<IngredientAmountCto>?> GetAllIngredientAmountsAsync()
        {
            List<IngredientAmountCto> ctos = new List<IngredientAmountCto>();
            List<IngredientAmountDto> dtos = await _service.IngredientAmount.Repository.GetAllAsync();

            foreach (IngredientAmountDto dto in dtos)
            {
                ctos.Add(_map.IngredientAmount.ToCto(from: dto));
            }

            return ctos;
        }

        public async Task<IngredientCto?> GetIngredientAsync(IngredientCto cto)
        {
            IngredientDto? dto = await _service.Ingredient.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.Ingredient.ToCto(from: dto);
        }
        public async Task<List<IngredientCto>?> GetAllIngredientsAsync()
        {
            List<IngredientCto> ctos = new List<IngredientCto>();
            List<IngredientDto> dtos = await _service.Ingredient.Repository.GetAllAsync();

            foreach (IngredientDto dto in dtos)
            {
                ctos.Add(_map.Ingredient.ToCto(from: dto));
            }

            return ctos;
        }

        public async Task<OrderCto?> GetOrderAsync(OrderCto cto)
        {
            OrderDto? dto = await _service.Order.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.Order.ToCto(from: dto);
        }
        public async Task<List<OrderCto>?> GetAllOrdersAsync()
        {
            List<OrderCto> ctos = new List<OrderCto>();
            List<OrderDto> dtos = await _service.Order.Repository.GetAllAsync();

            foreach (OrderDto dto in dtos)
            {
                ctos.Add(_map.Order.ToCto(from: dto));
            }

            return ctos;
        }

        public async Task<RecipeCto?> GetRecipeAsync(RecipeCto cto)
        {
            RecipeDto? dto = await _service.Recipe.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.Recipe.ToCto(from: dto);
        }
        public async Task<List<RecipeCto>?> GetAllRecipesAsync()
        {
            List<RecipeCto> ctos = new List<RecipeCto>();
            List<RecipeDto> dtos = await _service.Recipe.Repository.GetAllAsync();

            foreach (RecipeDto dto in dtos)
            {
                ctos.Add(_map.Recipe.ToCto(from: dto));
            }

            return ctos;
        }

        public async Task<UserAccountCto?> GetUserAccountAsync(UserAccountCto cto)
        {
            UserAccountDto? dto = await _service.User.Repository.GetAsync(cto.Id);

            if (dto == null) return null;

            return _map.User.ToCto(from: dto);
        }
        public async Task<List<UserAccountCto>?> GetAllUserAccountsAsync()
        {
            List<UserAccountCto> ctos = new List<UserAccountCto>();
            List<UserAccountDto> dtos = await _service.User.Repository.GetAllAsync();

            foreach (UserAccountDto dto in dtos)
            {
                ctos.Add(_map.User.ToCto(from: dto));
            }

            return ctos;
        }
    }
}
