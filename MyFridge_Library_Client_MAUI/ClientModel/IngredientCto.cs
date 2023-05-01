using MyFridge_Library_Client_MAUI.ClientModel.Interface;

namespace MyFridge_Library_Client_MAUI.ClientModel
{
    public class IngredientCto : ICto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public string Category { get; set; }
    }
}
