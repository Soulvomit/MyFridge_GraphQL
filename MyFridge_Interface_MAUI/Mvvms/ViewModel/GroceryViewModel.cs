using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_MAUI.Mvvms.Service.Client.Interface;
using MyFridge_Interface_MAUI.Mvvms.ViewModel.Detail;
using System.Collections.ObjectModel;

namespace MyFridge_Interface_MAUI.Mvvms.ViewModel
{
    public class GroceryViewModel : BindableObject
    {
        #region Privates
        private readonly IClientService _clientService;
        private ObservableCollection<DetailGroceryViewModel> groceryDetails;
        #endregion

        #region Properties
        public ObservableCollection<DetailGroceryViewModel> GroceryDetails
        {
            get => groceryDetails;
            private set
            {
                groceryDetails = value;

                OnPropertyChanged(nameof(GroceryDetails));
            }
        }
        public string Filter { get; set; } = string.Empty;
        #endregion

        public GroceryViewModel(IClientService clientService)
        {
            _clientService = clientService;
            groceryDetails = new();
        }
        public async Task RefreshAsync()
        {
            //IEnumerable<GroceryDto> groceries = await _clientService.GroceryClient.GetAllAsync();
            //GroceryDetails = ToViewModel(groceries.OrderBy(i => i.IngredientAmount.Ingredient.Name));
            await GetFiltered();
        }
        public void GetFilteredLazy(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                GroceryDetails = ToViewModel(_clientService.GroceryClient.AllLazies
                    .OrderBy(i => i.IngredientAmount.Ingredient.Name));
            else
                GroceryDetails = ToViewModel(_clientService.GroceryClient.AllLazies
                    .Where(i => i.IngredientAmount.Ingredient.Name.ToLower().StartsWith(filter.ToLower()))
                    .OrderBy(i => i.IngredientAmount.Ingredient.Name));
            //if (string.IsNullOrEmpty(filter))
            //    GroceryDetails = ToViewModel(_clientService.GroceryClient.AllLazies
            //        .OrderBy(i => i.IngredientAmount.Ingredient.Name));
            //else
            //    GroceryDetails = ToViewModel(_clientService.GroceryClient.AllLazies
            //        .Where(i => i.IngredientAmount.Ingredient.Name.ToLower().StartsWith(filter.ToLower()))
            //        .OrderBy(i => i.IngredientAmount.Ingredient.Name));
        }
        public async Task GetFiltered()
        {
            if(Filter.Length > 1)
            {
                IEnumerable<GroceryCto> groceries = await _clientService.GroceryClient.GetFilteredAsync(Filter);
                GroceryDetails = ToViewModel(groceries);
            }
        }
        public async Task Add(DetailGroceryViewModel grocery, string amountResult)
        {
            bool parsed = uint.TryParse(amountResult, out uint amount);
            if (parsed)
            {
                for (int i = 0; i < amount; i++)
                {
                    await _clientService.UserClient.AddIngredientAmountAsync(grocery.Grocery.IngredientAmount, _clientService.UserClient.Lazy.Id);
                }
            }
        }
        private ObservableCollection<DetailGroceryViewModel> ToViewModel(IEnumerable<GroceryCto> groceries)
        {
            ObservableCollection<DetailGroceryViewModel> viewModels = new();
            foreach (GroceryCto dto in groceries)
            {
                DetailGroceryViewModel viewModel = new(_clientService)
                {
                    Grocery = dto
                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
    }
}
