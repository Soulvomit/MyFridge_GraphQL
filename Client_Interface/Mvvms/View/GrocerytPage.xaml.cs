using Client_Interface.Mvvms.Service.Navigation.Interface;
using Client_Interface.Mvvms.ViewModel;
using Client_Interface.Mvvms.ViewModel.Detail;

namespace Client_Interface.Mvvms.View;

public partial class GroceryPage : ContentPage
{
    private readonly GroceryViewModel _viewModel;
    private readonly INavigationService _navigationService;
    public GroceryPage(INavigationService navigationService, GroceryViewModel viewModel)
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
        _viewModel.Filter = e.NewTextValue;
        _viewModel.GetFilteredLazy(e.NewTextValue);
    }
    private async void OnIngredientSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is DetailGroceryViewModel selected)
        {
            string amount = await DisplayPromptAsync( "Add Amount", "Enter the amount", "OK", 
                                                            "Cancel", "0", -1, Keyboard.Numeric, "");
            await _viewModel.Add(selected, amount);
            //navigate back
            //await _navigationService.GoBack();
        }
        //deselect the item
        (sender as CollectionView).SelectedItem = null;
    }

    private async void OnSearchButtonPressed(object sender, EventArgs e)
    {
        await _viewModel.GetFiltered();
    }
}