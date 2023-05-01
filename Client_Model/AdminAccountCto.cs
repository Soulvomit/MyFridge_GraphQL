using Client_Model.Interface;
using HotChocolate;

namespace Client_Model
{
    public class AdminAccountCto : ICto
    {
        [GraphQLType(typeof(int?))]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string EmployeeNumber { get; set; }
    }
}
