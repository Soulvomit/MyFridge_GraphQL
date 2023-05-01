using Client_Model.Interface;
using HotChocolate;

namespace Client_Model
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
    }
}
