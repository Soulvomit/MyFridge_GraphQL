using Client_Interface.Mvvms.Service.Client.Interface;
using Client_Model.Model;

namespace Client_Interface.Mvvms.ViewModel
{
    public class UserLoginViewModel : BindableObject
    {
        #region Privates
        private readonly IClientService _clientService;
        private string loginResultMessage;
        private string entryEmail;
        private string entryPassword;
        #endregion

        #region Properties
        public string EntryEmail
        {
            get => entryEmail;
            set
            {
                entryEmail = value;
                OnPropertyChanged(nameof(EntryEmail));
            }
        }
        public string EntryPassword
        {
            get => entryPassword;
            set
            {
                entryPassword = value;
                OnPropertyChanged(nameof(EntryPassword));
            }
        }
        public string LoginResultMessage
        {
            get => loginResultMessage;
            set
            {
                loginResultMessage = value;
                OnPropertyChanged(nameof(LoginResultMessage));
            }
        }
        #endregion

        public UserLoginViewModel(IClientService clientService)
        {
            _clientService = clientService;

            //for testing
            EntryEmail = "email@email.com";
            EntryPassword = "password";
        }

        public async Task<bool> LoginAsync()
        {
            UserAccountCto user = await _clientService.UserClient.GetByEmailAsync(EntryEmail);

            if (user.Id != 0)
            {
                if (EntryPassword == user.Password)
                {
                    return true;
                }
                else
                {
                    LoginResultMessage = "Invalid password";
                }
            }
            else
            {
                LoginResultMessage = "Invalid email";
            }
            return false;
        }
    }
}
