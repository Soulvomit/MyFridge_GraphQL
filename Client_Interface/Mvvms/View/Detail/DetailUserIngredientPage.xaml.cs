using Client_Interface.Mvvms.Service.Navigation.Interface;
using Client_Interface.Mvvms.ViewModel.Detail;
using Client_Model.Model;

namespace Client_Interface.Mvvms.View.Detail;

public partial class DetailUserIngredientPage : ContentPage
{
    private readonly DetailIngredientViewModel _viewModel;
    private readonly INavigationService _navigationService;
    public DetailUserIngredientPage(INavigationService navigationService, DetailIngredientViewModel viewModel)
    {
        InitializeComponent();

        _navigationService = navigationService;
        _viewModel = viewModel;
        _viewModel.IngredientAmount = _navigationService.GetDataStore<IngredientAmountCto>();
        BindingContext = _viewModel;
    }
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        await _viewModel.SaveAsync();
        await _navigationService.GoBack();
    }
    private void OnAmountCompleted(object sender, EventArgs e)
    {
        (sender as Entry).Unfocus();
    }
}