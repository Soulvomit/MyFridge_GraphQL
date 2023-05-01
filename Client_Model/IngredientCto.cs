using Client_Model.Interface;
using HotChocolate;

namespace Client_Model
{
    public class IngredientCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public string Name { get; set; }
        [GraphQLType(typeof(int?))]
        public int Unit { get; set; }
        public string Category { get; set; }
    }
}
