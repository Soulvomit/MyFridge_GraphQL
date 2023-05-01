using Client_Interface.Mvvms.Service.Client.Interface;
using Client_Model;

namespace Client_Interface.Mvvms.ViewModel.Detail
{
    public class DetailIngredientViewModel : BindableObject
    {
        #region Privates
        private readonly IClientService _clientService;
        private IngredientAmountCto ingredientAmount;
        #endregion

        #region Properties
        public IngredientAmountCto IngredientAmount
        {
            get => ingredientAmount;
            set
            {
                ingredientAmount = value;
                OnPropertyChanged(nameof(IngredientAmount));
            }
        }
        public string Name
        {
            get => IngredientAmount.Ingredient.Name;
            set
            {
                IngredientAmount.Ingredient.Name = value;

                OnPropertyChanged(nameof(Name));
            }
        }
        public float Amount
        {
            get => IngredientAmount.Amount;
            set
            {
                IngredientAmount.Amount = value;

                OnPropertyChanged(nameof(Amount));
            }
        }
        public DateTime? ExpirationDate
        {
            get => IngredientAmount.ExpirationDate;
            set
            {
                IngredientAmount.ExpirationDate = value;

                OnPropertyChanged(nameof(ExpirationDate));
            }
        }
        public bool CurrentUserHas
        {
            get
            {
                UserAccountCto user = _clientService.UserClient.CachedItem;
                IngredientAmountCto test = user.IngredientAmounts
                    .FirstOrDefault(i => i.Ingredient.Id == IngredientAmount.Ingredient.Id);
                return test != null;
            }
        }
        public string ExpirationDateStr
        {
            get
            {
                if (IngredientAmount.ExpirationDate == null)
                    return null;

                return ((DateTime)IngredientAmount.ExpirationDate).ToShortDateString();
            }
        }
        public string UnitStr
        {
            get
            {
                if (IngredientAmount.Ingredient.Unit == 2)
                    return "gram";
                if (IngredientAmount.Ingredient.Unit == 1)
                    return "ml";
                else
                {
                    if (Amount > 1)
                        return "pcs";
                    else
                        return "pc";
                }
            }
        }
        public Color NameColor { get; set; } = Colors.White;
        public Color AmountColor { get; set; } = Colors.White;
        #endregion

        public DetailIngredientViewModel(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task SaveAsync()
        {
            IngredientAmount = await _clientService.IngredientAmountClient.UpsertAsync(IngredientAmount);
        }
        public void Update()
        {
            UserAccountCto user = _clientService.UserClient.CachedItem;

            IngredientAmountCto userIngredientAmount = user.IngredientAmounts
                .FirstOrDefault(ui => ui.Ingredient.Id == IngredientAmount.Ingredient.Id);

            NameColor = Color.FromArgb("#FF6B6B");
            AmountColor = Color.FromArgb("#FF6B6B");

            if (userIngredientAmount != null)
            {
                NameColor = Color.FromArgb("#4CAF50");

                if (userIngredientAmount.Amount >= IngredientAmount.Amount)
                    AmountColor = Color.FromArgb("#4CAF50");
            }
        }
    }
}
