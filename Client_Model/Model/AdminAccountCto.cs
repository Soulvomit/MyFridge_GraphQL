using Client_Model.Model.Interface;
using HotChocolate;
using System.IO;
using System.Reflection.Emit;

namespace Client_Model.Model
{
    public class AdminAccountCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmployeeNumber { get; set; }
        public string SerializeToCreateInputType()
        {
            return $$"""
                    { 
                        {{FormatHelper.PascalToCamel(nameof(FirstName))}}:{{FormatHelper.FormatNullableInput(FirstName)}}
                        {{FormatHelper.PascalToCamel(nameof(LastName))}}:{{FormatHelper.FormatNullableInput(LastName)}}
                        {{FormatHelper.PascalToCamel(nameof(Password))}}:{{FormatHelper.FormatNullableInput(Password)}}
                        {{FormatHelper.PascalToCamel(nameof(EmployeeNumber))}}:{{FormatHelper.FormatNullableInput(EmployeeNumber)}}    
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
                        {{FormatHelper.PascalToCamel(nameof(EmployeeNumber))}}:{{FormatHelper.FormatNullableInput(EmployeeNumber)}}    
                    }
                    """;
        }
    }
}
