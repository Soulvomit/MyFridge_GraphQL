using Client_Model.Model.Interface;
using HotChocolate;

namespace Client_Model.Model
{
    public class IngredientAmountCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public IngredientCto Ingredient { get; set; }
        [GraphQLType(typeof(float?))]
        public float Amount { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string SerializeToCreateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Amount))}}:{{Amount}}
                        {{FormatHelper.PascalToCamel(nameof(ExpirationDate))}}:{{FormatHelper.FormatNullableInput(ExpirationDate)}}
                        {{SerializeIngredientToInputType}}
                    }
                    """;
        }
        public string SerializeToUpdateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Id))}}:{{Id}}
                        {{FormatHelper.PascalToCamel(nameof(Amount))}}:{{Amount}}
                        {{FormatHelper.PascalToCamel(nameof(ExpirationDate))}}:{{FormatHelper.FormatNullableInput(ExpirationDate)}}
                        {{SerializeIngredientToInputType}}
                    }
                    """;
        }
        private string SerializeIngredientToInputType()
        {
            if (Ingredient == null) return string.Empty;

            return $"ingredient{Ingredient.SerializeToCreateInputType()}";
        }
    }
}
