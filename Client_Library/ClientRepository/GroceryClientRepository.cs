using Client_Library.Abstract;
using Client_Library.Interface;
using Client_Model;

namespace Client_Library.ClientRepository
{
    public class GroceryClientRepository : ClientRepository<GroceryCto>, IGroceryClientRepository
    {
        public GroceryClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
