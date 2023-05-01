using MyFridge_Library_Client_MAUI.ClientModel;

namespace MyFridge_Interface_MAUI.Mvvms.Service.Navigation.Interface
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
