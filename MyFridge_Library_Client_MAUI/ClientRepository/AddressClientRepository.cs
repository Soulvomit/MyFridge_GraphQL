using MyFridge_Library_Client_MAUI.ClientRepository.Abstract;
using MyFridge_Library_Client_MAUI.ClientRepository.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;

namespace MyFridge_Library_Client_MAUI.ClientRepository
{
    public class AddressClientRepository : ClientRepository<AddressCto>, IAddressClientRepository
    {
        public AddressClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
