using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Interface_MAUI.Mvvms.Service.Client.Interface;

namespace MyFridge_Interface_MAUI.Mvvms.ViewModel.Detail
{
    public class DetailGroceryViewModel : BindableObject
    {
        #region Privates
        private readonly IClientService _clientService;
        private GroceryCto grocery;
        #endregion 

        #region Properties
        public GroceryCto Grocery
        {
            get => grocery;
            set
            {
                grocery = value;

                OnPropertyChanged(nameof(Grocery));
            }
        }
        public string Brand
        {
            get => Grocery.Brand;
        }
        public float Price
        {
            get => Grocery.SalePrice;
        }
        public string ItemIdentifier
        {
            get => Grocery.ItemIdentifier;
        }        
        public float Amount
        {
            get => Grocery.IngredientAmount.Amount;
        }
        public string Name
        {
            get => Grocery.IngredientAmount.Ingredient.Name;
        }
        public string Category
        {
            get => Grocery.IngredientAmount.Ingredient.Category;
        }
        public string UnitStr
        {
            get
            {
                if (Grocery.IngredientAmount.Ingredient.Unit == 2)
                    return "gram";
                if (Grocery.IngredientAmount.Ingredient.Unit == 1)
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
        #endregion

        public DetailGroceryViewModel(IClientService clientService)
        {
            _clientService = clientService;
        }
    }
}
