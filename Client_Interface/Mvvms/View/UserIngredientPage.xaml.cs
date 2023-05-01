using Client_Interface.Mvvms.Service.Navigation.Interface;
using Client_Interface.Mvvms.ViewModel;
using Client_Interface.Mvvms.ViewModel.Detail;

namespace Client_Interface.Mvvms.View;

public partial class UserIngredientPage : ContentPage
{
    private readonly UserIngredientViewModel _viewModel;
    private readonly INavigationService _navigationService;
    public UserIngredientPage(INavigationService navigationService, UserIngredientViewModel viewModel)
    {
        InitializeComponent();

        _navigationService = navigationService;
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.RefreshAsync();
    }
    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        _viewModel.GetFilteredLazy(e.NewTextValue);
    }
    private async void OnIngredientSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is DetailIngredientViewModel selected)
            await _navigationService.GoToIngredientDetailAsync(selected.IngredientAmount);

        //deselect the item
        (sender as CollectionView).SelectedItem = null;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        await _navigationService.GoToGroceriesAsync();
    }
}