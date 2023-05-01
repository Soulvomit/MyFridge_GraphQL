using Data_Model.Abstract;
using Data_Model.Enum;

namespace Data_Model
{
    public class OrderDto : DatabaseItem
    {
        public EOrderStatus Status { get; set; } = EOrderStatus.Pending;
        public virtual ICollection<GroceryDto> Groceries { get; set; } = new List<GroceryDto>();
    }
}
