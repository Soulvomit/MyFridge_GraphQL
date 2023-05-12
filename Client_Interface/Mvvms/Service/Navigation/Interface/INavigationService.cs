using Client_Model.Model;

namespace Client_Interface.Mvvms.Service.Navigation.Interface
{
    public interface INavigationService
    {
        public void SetDataStore(object data);
        public T GetDataStore<T>();
        public Task GoBack();
        public Task GoToIngredientDetailAsync(IngredientAmountCto ingredientAmount);
        public Task GoToRecipeDetailAsync(RecipeCto recipe);
        public Task GoToGroceriesAsync();
        public Task GoToUserAbsoluteAsync();
        public Task GoToLoginAbsoluteAsync();
    }
}
