using Client_Interface.Mvvms.Service.Navigation.Interface;
using Client_Interface.Mvvms.ViewModel.Detail;
using Client_Model.Model;

namespace Client_Interface.Mvvms.View.Detail;

public partial class DetailRecipePage : ContentPage
{
	private readonly DetailRecipeViewModel _viewModel;
    private readonly INavigationService _navigationService;
    public DetailRecipePage(INavigationService navigationService, DetailRecipeViewModel viewModel)
	{
		InitializeComponent();

        _navigationService = navigationService;
		_viewModel = viewModel;
        _viewModel.Recipe = _navigationService.GetDataStore<RecipeCto>();
        BindingContext = _viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        _viewModel.RefreshAsync();
    }
    private async void OnIngredientSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is DetailIngredientViewModel selected)
            //await _navigationService.GoToIngredientDetailAsync(selected.IngredientAmount);

        //deselect the item
        (sender as CollectionView).SelectedItem = null;
    }
}