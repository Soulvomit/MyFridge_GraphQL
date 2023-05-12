using Client_Interface.Mvvms.Service.Navigation.Interface;
using Client_Interface.Mvvms.View;
using Client_Interface.Mvvms.View.Detail;
using Client_Model.Model;

namespace Client_Interface.Mvvms.Service.Navigation
{
    public class NavigationService : INavigationService
    {
        private object _dataStore;

        public void SetDataStore(object data)
        {
            _dataStore = data;
        }
        public T GetDataStore<T>()
        {
            return (T)_dataStore;
        }
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync($"..");
        }
        public async Task GoToIngredientDetailAsync(IngredientAmountCto ingredientAmount)
        {
            SetDataStore(ingredientAmount);
            await Shell.Current.GoToAsync(nameof(DetailUserIngredientPage));
        }
        public async Task GoToRecipeDetailAsync(RecipeCto recipe)
        {
            SetDataStore(recipe);
            await Shell.Current.GoToAsync(nameof(DetailRecipePage));
        }
        public async Task GoToGroceriesAsync()
        {
            await Shell.Current.GoToAsync(nameof(GroceryPage));
        }
        public async Task GoToUserAbsoluteAsync()
        {
            await Shell.Current.GoToAsync($"//" + nameof(UserInfoPage));
        }
        public async Task GoToLoginAbsoluteAsync()
        {
            await Shell.Current.GoToAsync($"//" + nameof(UserLoginPage));
        }
    }
}
