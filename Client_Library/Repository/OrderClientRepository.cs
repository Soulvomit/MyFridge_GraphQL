using Client_Library.Repository.Abstract;
using Client_Library.Repository.Interface;
using Client_Model.Model;

namespace Client_Library.Repository
{
    public class OrderClientRepository : ClientRepository<OrderCto>, IOrderClientRepository
    {
        public OrderClientRepository(string baseAddress) : base(baseAddress) { }
    }
}
