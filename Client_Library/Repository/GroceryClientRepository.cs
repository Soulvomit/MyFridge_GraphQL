using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model.Model;

namespace Client_Library.Repository
{
    public class GroceryClientRepository : ClientRepository<GroceryCto>, IGroceryClientRepository
    {
        public GroceryClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
