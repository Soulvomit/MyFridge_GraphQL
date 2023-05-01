using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_MAUI.Mvvms.Service.Client.Interface;
using MyFridge_Interface_MAUI.Mvvms.ViewModel.Detail;
using System.Collections.ObjectModel;

namespace MyFridge_Interface_MAUI.Mvvms.ViewModel
{
    public class RecipeViewModel : BindableObject
    {
        #region Privates
        private readonly IClientService _clientService;
        private ObservableCollection<DetailRecipeViewModel> recipeDetails;
        private bool toggle = false;
        #endregion

        #region Properties
        public ObservableCollection<DetailRecipeViewModel> RecipeDetails
        {
            get => recipeDetails;
            private set
            {
                recipeDetails = value;
                OnPropertyChanged(nameof(RecipeDetails));
            }
        }
        public bool Toggle
        {
            get => toggle;
            set
            {
                toggle = value;
                OnPropertyChanged(nameof(Toggle));
            }
        }
        #endregion

        public RecipeViewModel(IClientService clientService)
        {
            _clientService = clientService;

            recipeDetails = new();
        }
        public async Task RefreshAsync()
        {
            await _clientService.RecipeClient.GetAllAsync();
            await _clientService.RecipeClient.GetMakeableAsync(_clientService.UserClient.Lazy.Id);

            GetFilteredLazy(string.Empty);
        }
        public void GetFilteredLazy(string filter)
        {
            IEnumerable<RecipeCto> show;

            if (toggle) show = _clientService.RecipeClient.AllLazies;
            else show = _clientService.RecipeClient.MakeableLazies;

            RecipeDetails = ToViewModel(show.Where(recipe =>
                        recipe.Name.ToLower().Contains(filter) || recipe.IngredientAmounts.Any(ia =>
                           ia.Ingredient.Name.ToLower().StartsWith(filter.ToLower())))
                .OrderBy(recipe => recipe.Name));
        }
        private ObservableCollection<DetailRecipeViewModel> ToViewModel(IEnumerable<RecipeCto> recipes)
        {
            ObservableCollection<DetailRecipeViewModel> viewModels = new();
            foreach (RecipeCto recipe in recipes)
            {
                DetailRecipeViewModel viewModel = new(_clientService)
                {
                    Recipe = recipe
                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
    }
}
