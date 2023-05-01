using Client_Interface.Mvvms.Service.Navigation.Interface;
using Client_Interface.Mvvms.ViewModel;

namespace Client_Interface.Mvvms.View;

public partial class UserInfoPage : ContentPage
{
    private readonly UserViewModel _viewModel;
    private readonly INavigationService _navigationService;
    public UserInfoPage(INavigationService navigationService, UserViewModel viewModel)
    {
        InitializeComponent();

        _navigationService = navigationService;
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        await _viewModel.SaveAsync();
    }
}