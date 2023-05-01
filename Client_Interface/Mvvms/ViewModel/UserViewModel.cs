using Client_Interface.Mvvms.Service.Client.Interface;
using Client_Model;

namespace Client_Interface.Mvvms.ViewModel
{
    public class UserViewModel : BindableObject
    {
        #region Privates
        private readonly IClientService _clientService;
        private UserAccountCto user;
        #endregion

        #region Properties
        public UserAccountCto User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(FirstName)) return false;
                if (string.IsNullOrEmpty(LastName)) return false;
                if (string.IsNullOrEmpty(Email)) return false;
                if (string.IsNullOrEmpty(Password)) return false;
                if (!ulong.TryParse(PhoneNumber.ToString(), out ulong phoneNumber)) return false;

                return true;
            }
        }
        public string FirstName
        {
            get => User.FirstName;
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                User.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => User.LastName;
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                User.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string Email
        {
            get => User.Email;
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                User.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => User.Password;
            set
            {
                if (string.IsNullOrEmpty(value)) return;

                User.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string PhoneNumber
        {
            get => User.PhoneNumber.ToString();
            set
            {
                if (!ulong.TryParse(value, out ulong phoneNumber)) return;

                User.PhoneNumber = phoneNumber;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public DateTime? BirthDate
        {
            get => User.BirthDate;
            set
            {
                User.BirthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }
        #endregion

        public UserViewModel(IClientService clientService)
        {
            _clientService = clientService;

            User = _clientService.UserClient.CachedItem;
        }

        public async Task SaveAsync()
        {
            if (!IsValid) return;

            User = await _clientService.UserClient.UpsertAsync(_clientService.UserClient.CachedItem);
        }
    }
}
