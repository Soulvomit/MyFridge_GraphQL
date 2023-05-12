using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model.Model;

namespace Client_Library.Repository
{
    public class AddressClientRepository : ClientRepository<AddressCto>, IAddressClientRepository
    {
        public AddressClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
