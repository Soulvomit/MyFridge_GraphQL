using MyFridge_Library_Client_MAUI.ClientModel.Interface;

namespace MyFridge_Library_Client_MAUI.ClientModel
{
    public class IngredientAmountCto : ICto
    {
        public int Id { get; set; }
        public IngredientCto Ingredient { get; set; }
        public float Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
