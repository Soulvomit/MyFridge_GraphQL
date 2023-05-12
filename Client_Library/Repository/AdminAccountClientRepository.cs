using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model.Model;

namespace Client_Library.Repository
{
    public class AdminAccountClientRepository : ClientRepository<AdminAccountCto>, IAdminAccountClientRepository
    {
        public AdminAccountClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
