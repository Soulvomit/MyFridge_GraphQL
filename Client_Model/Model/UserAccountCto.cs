using Client_Model.Model.Interface;
using HotChocolate;

namespace Client_Model.Model
{
    public class UserAccountCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public AddressCto Address { get; set; }
        public List<IngredientAmountCto> IngredientAmounts { get; set; }
            = new List<IngredientAmountCto>();
        public List<OrderCto> Orders { get; set; } = new List<OrderCto>();

        public string SerializeToCreateInputType()
        {
            return $$"""
                    {    
                        {{FormatHelper.PascalToCamel(nameof(FirstName))}}:{{FormatHelper.FormatNullableInput(FirstName)}}
                        {{FormatHelper.PascalToCamel(nameof(LastName))}}:{{FormatHelper.FormatNullableInput(LastName)}}
                        {{FormatHelper.PascalToCamel(nameof(Password))}}:{{FormatHelper.FormatNullableInput(Password)}}
                        {{FormatHelper.PascalToCamel(nameof(Email))}}:{{FormatHelper.FormatNullableInput(Email)}} 
                        {{FormatHelper.PascalToCamel(nameof(BirthDate))}}:{{FormatHelper.FormatNullableInput(BirthDate)}}
                        {{SerializeAddressToInputType}}
                    }
                    """;
        }
        public string SerializeToUpdateInputType()
        {
            return $$"""
                    { 
                        {{FormatHelper.PascalToCamel(nameof(Id))}}:{{Id}}
                        {{FormatHelper.PascalToCamel(nameof(FirstName))}}:{{FormatHelper.FormatNullableInput(FirstName)}}
                        {{FormatHelper.PascalToCamel(nameof(LastName))}}:{{FormatHelper.FormatNullableInput(LastName)}}
                        {{FormatHelper.PascalToCamel(nameof(Password))}}:{{FormatHelper.FormatNullableInput(Password)}}
                        {{FormatHelper.PascalToCamel(nameof(Email))}}:{{FormatHelper.FormatNullableInput(Email)}} 
                        {{FormatHelper.PascalToCamel(nameof(BirthDate))}}:{{FormatHelper.FormatNullableInput(BirthDate)}}
                        {{SerializeAddressToInputType}}
                    }
                    """;
        }
        private string SerializeAddressToInputType()
        {
            if (Address == null) return string.Empty;

            return $"address{Address.SerializeToCreateInputType()}";
        }
    }
}
