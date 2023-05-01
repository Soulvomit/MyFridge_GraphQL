using Client_Library.Abstract;
using Client_Library.Interface;
using Client_Model;

namespace Client_Library.ClientRepository
{
    public class AdminAccountClientRepository : ClientRepository<AdminAccountCto>, IAdminAccountClientRepository
    {
        public AdminAccountClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
