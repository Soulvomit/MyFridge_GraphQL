using Client_Library.Abstract;
using Client_Library.Interface;
using Client_Model;

namespace Client_Library.ClientRepository
{
    public class AddressClientRepository : ClientRepository<AddressCto>, IAddressClientRepository
    {
        public AddressClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
