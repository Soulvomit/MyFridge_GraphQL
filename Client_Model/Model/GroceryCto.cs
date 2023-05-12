using Client_Model.Model.Interface;
using HotChocolate;

namespace Client_Model.Model
{
    public class GroceryCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public IngredientAmountCto IngredientAmount { get; set; }
        public string Brand { get; set; }
        public string ItemIdentifier { get; set; }
        [GraphQLType(typeof(float?))]
        public float SalePrice { get; set; }
        public string ImageUrl { get; set; }
    }
}
