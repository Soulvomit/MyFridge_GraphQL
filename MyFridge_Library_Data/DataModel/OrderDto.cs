using MyFridge_Library_Data.DataModel.Abstract;
using MyFridge_Library_Data.DataModel.Enum;

namespace MyFridge_Library_Data.DataModel
{
    public class OrderDto : DatabaseItem
    {
        public EOrderStatus Status { get; set; } = EOrderStatus.Pending;
        public virtual ICollection<GroceryDto> Groceries { get; set; } = new List<GroceryDto>();
    }
}
