using HotChocolate;
using MyFridge_Library_Client_MAUI.ClientModel.Interface;

namespace MyFridge_Library_Client_MAUI.ClientModel
{
    public class OrderCto : ICto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public int Status { get; set; }
        public List<GroceryCto> Groceries { get; set; } = new List<GroceryCto>();
        [GraphQLIgnore]
        public float TotalPriceDkk
        {
            get
            {
                float total = 0;

                foreach (var item in Groceries)
                    total += item.SalePrice;

                return total;
            }
        }
    }
}
