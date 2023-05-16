using Client_Model.Model.Interface;
using HotChocolate;

namespace Client_Model.Model
{
    public class AddressCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Extension { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [GraphQLType(typeof(int?))]
        public int Country { get; set; }
        public string SerializeToCreateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Street))}}:{{FormatHelper.FormatNullableInput(Street)}}
                        {{FormatHelper.PascalToCamel(nameof(Extension))}}:{{FormatHelper.FormatNullableInput(Extension)}}
                        {{FormatHelper.PascalToCamel(nameof(City))}}:{{FormatHelper.FormatNullableInput(City)}}
                        {{FormatHelper.PascalToCamel(nameof(State))}}:{{FormatHelper.FormatNullableInput(State)}}
                        {{FormatHelper.PascalToCamel(nameof(ZipCode))}}:{{FormatHelper.FormatNullableInput(ZipCode)}}
                        {{FormatHelper.PascalToCamel(nameof(Country))}}:{{Country}}
                    }
                    """;
        }
        public string SerializeToUpdateInputType()
        {
            return $$"""
                    {
                        {{FormatHelper.PascalToCamel(nameof(Id))}}:{{Id}}
                        {{FormatHelper.PascalToCamel(nameof(Street))}}:{{FormatHelper.FormatNullableInput(Street)}}
                        {{FormatHelper.PascalToCamel(nameof(Extension))}}:{{FormatHelper.FormatNullableInput(Extension)}}
                        {{FormatHelper.PascalToCamel(nameof(City))}}:{{FormatHelper.FormatNullableInput(City)}}
                        {{FormatHelper.PascalToCamel(nameof(State))}}:{{FormatHelper.FormatNullableInput(State)}}
                        {{FormatHelper.PascalToCamel(nameof(ZipCode))}}:{{FormatHelper.FormatNullableInput(ZipCode)}}
                        {{FormatHelper.PascalToCamel(nameof(Country))}}:{{Country}}
                    }
                    """;
        }
    }
}
