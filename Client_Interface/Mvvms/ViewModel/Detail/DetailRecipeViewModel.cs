using Client_Interface.Mvvms.Service.Client.Interface;
using Client_Model.Model;
using System.Collections.ObjectModel;

namespace Client_Interface.Mvvms.ViewModel.Detail
{
    public class DetailRecipeViewModel : BindableObject
    {
        #region Privates
        private readonly IClientService _clientService;
        private ObservableCollection<DetailIngredientViewModel> recipeIngredientDetails;
        private RecipeCto recipe;
        #endregion

        #region Properties
        public RecipeCto Recipe
        {
            get => recipe;
            set
            {
                recipe = value;
                OnPropertyChanged(nameof(Recipe));
            }
        }
        public ObservableCollection<DetailIngredientViewModel> RecipeIngredientDetails
        {
            get => recipeIngredientDetails;
            set
            {
                recipeIngredientDetails = value;
                OnPropertyChanged(nameof(RecipeIngredientDetails));
            }
        }
        public bool IsMakable
        {
            get
            {
                UserAccountCto user = _clientService.UserClient.CachedItem;
                return Recipe.IngredientAmounts.All(recipeIngredient =>
                    user.IngredientAmounts.Any(userIngredient =>
                        recipeIngredient.Ingredient.Id == userIngredient.Ingredient.Id &&
                        recipeIngredient.Amount <= userIngredient.Amount));
            }
        }
        public string Name
        {
            get => Recipe.Name;
        }
        public string Method
        {
            get => Recipe.Method;
        }
        public Color TextColor { get; set; }
        #endregion

        public DetailRecipeViewModel(IClientService clientService)
        {
            _clientService = clientService;

            recipeIngredientDetails = new ObservableCollection<DetailIngredientViewModel>();
        }

        public void RefreshAsync()
        {
            RecipeIngredientDetails = ToViewModel(Recipe.IngredientAmounts.OrderBy(i => i.Ingredient.Name));
            foreach (DetailIngredientViewModel viewModel in RecipeIngredientDetails)
            {
                viewModel.Update();
            }
        }
        private ObservableCollection<DetailIngredientViewModel> ToViewModel(IEnumerable<IngredientAmountCto> ingredients)
        {
            ObservableCollection<DetailIngredientViewModel> viewModels = new();
            foreach (IngredientAmountCto dto in ingredients)
            {
                DetailIngredientViewModel viewModel = new(_clientService)
                {
                    IngredientAmount = dto
                };
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
    }
}
