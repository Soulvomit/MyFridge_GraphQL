using Client_Interface.Mvvms.Service.Navigation.Interface;
using Client_Interface.Mvvms.ViewModel;

namespace Client_Interface.Mvvms.View
{
    public partial class UserLoginPage : ContentPage
    {
        private readonly UserLoginViewModel _viewModel;
        private readonly INavigationService _navigationService;
        public UserLoginPage(INavigationService navigationService, UserLoginViewModel viewModel)
        {
            InitializeComponent();

            _navigationService = navigationService;
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }
        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            bool success = await _viewModel.LoginAsync();
            if (success)
            {
                await _navigationService.GoToUserAbsoluteAsync();
            }
        }
    }
}