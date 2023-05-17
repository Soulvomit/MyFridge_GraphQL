using Client_Library.Repository.Interface.Base;
using Client_Model.Model;

namespace Client_Library.Repository.Interface
{
    public interface IGroceryClientRepository : IClientRepository<GroceryCto>
    {
        public Task<GroceryCto> ChangeAsync(GroceryCto cto, string nodeItems, bool core = false);
    }
}
