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
        public string SerializeToCreateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Brand))}}:{{FormatHelper.FormatNullableInput(Brand)}}
                        {{FormatHelper.PascalToCamel(nameof(ItemIdentifier))}}:{{FormatHelper.FormatNullableInput(ItemIdentifier)}}
                        {{FormatHelper.PascalToCamel(nameof(SalePrice))}}:{{SalePrice}}
                        {{FormatHelper.PascalToCamel(nameof(ImageUrl))}}:{{FormatHelper.FormatNullableInput(ImageUrl)}}
                        {{SerializeIngredientAmountToInputType()}}
                    }
                    """;
        }
        public string SerializeToUpdateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Id))}}:{{Id}}
                        {{FormatHelper.PascalToCamel(nameof(Brand))}}:{{FormatHelper.FormatNullableInput(Brand)}}
                        {{FormatHelper.PascalToCamel(nameof(ItemIdentifier))}}:{{FormatHelper.FormatNullableInput(ItemIdentifier)}}
                        {{FormatHelper.PascalToCamel(nameof(SalePrice))}}:{{SalePrice}}
                        {{FormatHelper.PascalToCamel(nameof(ImageUrl))}}:{{FormatHelper.FormatNullableInput(ImageUrl)}}
                        {{SerializeIngredientAmountToInputType()}}
                    }
                    """;
        }
        private string SerializeIngredientAmountToInputType() 
        {
            if (IngredientAmount == null) return string.Empty;

            return $"ingredientAmount {IngredientAmount.SerializeToCreateInputType()}";
        }
    }
}
