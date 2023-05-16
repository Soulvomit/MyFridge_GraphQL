using Client_Model.Model.Interface;
using HotChocolate;

namespace Client_Model.Model
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

        public string SerializeToCreateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Name))}}:{{FormatHelper.FormatNullableInput(Name)}}
                        {{FormatHelper.PascalToCamel(nameof(Method))}}:{{FormatHelper.FormatNullableInput(Method)}}
                        {{FormatHelper.PascalToCamel(nameof(ImageUrl))}}:{{FormatHelper.FormatNullableInput(ImageUrl)}}
                    }
                    """;
        }
        public string SerializeToUpdateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Id))}}:{{Id}}
                        {{FormatHelper.PascalToCamel(nameof(Name))}}:{{FormatHelper.FormatNullableInput(Name)}}
                        {{FormatHelper.PascalToCamel(nameof(Method))}}:{{FormatHelper.FormatNullableInput(Method)}}
                        {{FormatHelper.PascalToCamel(nameof(ImageUrl))}}:{{FormatHelper.FormatNullableInput(ImageUrl)}}
                    }
                    """;
        }
    }
}
