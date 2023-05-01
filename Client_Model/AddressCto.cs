using Client_Model.Interface;
using HotChocolate;

namespace Client_Model
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
    }
}
