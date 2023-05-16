using Client_Model.Model.Interface;
using HotChocolate;

namespace Client_Model.Model
{
    public class IngredientCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public string Name { get; set; }
        [GraphQLType(typeof(int?))]
        public int Unit { get; set; }
        public string Category { get; set; }

        public string SerializeToCreateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Unit))}}:{{Unit}}
                        {{FormatHelper.PascalToCamel(nameof(Name))}}:{{FormatHelper.FormatNullableInput(Name)}}
                        {{FormatHelper.PascalToCamel(nameof(Category))}}:{{FormatHelper.FormatNullableInput(Category)}}
                    }
                    """;
        }
        public string SerializeToUpdateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Id))}}:{{Id}}
                        {{FormatHelper.PascalToCamel(nameof(Unit))}}:{{Unit}}
                        {{FormatHelper.PascalToCamel(nameof(Name))}}:{{FormatHelper.FormatNullableInput(Name)}}
                        {{FormatHelper.PascalToCamel(nameof(Category))}}:{{FormatHelper.FormatNullableInput(Category)}}
                    }
                    """;
        }
    }
}
