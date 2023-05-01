using Client_Model.Interface;
using HotChocolate;

namespace Client_Model
{
    public class RecipeCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<IngredientAmountCto> IngredientAmounts { get; set; } 
            = new List<IngredientAmountCto>();
        public string Method { get; set; }
        public string ImageUrl { get; set; }
    }
}
