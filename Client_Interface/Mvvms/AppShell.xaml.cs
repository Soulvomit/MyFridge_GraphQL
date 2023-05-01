using Client_Interface.Mvvms.View;
using Client_Interface.Mvvms.View.Detail;

namespace Client_Interface.Mvvms
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailRecipePage), typeof(DetailRecipePage));
            Routing.RegisterRoute(nameof(DetailUserIngredientPage), typeof(DetailUserIngredientPage));
            Routing.RegisterRoute(nameof(GroceryPage), typeof(GroceryPage));
            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
            Routing.RegisterRoute(nameof(UserInfoPage), typeof(UserInfoPage));
            Routing.RegisterRoute(nameof(UserIngredientPage), typeof(UserIngredientPage));
            Routing.RegisterRoute(nameof(UserLoginPage), typeof(UserLoginPage));
        }
    }
}