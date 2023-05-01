using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Data_Interface.Service.Mapper
{
    public class OrderMapper : IMapperService<OrderDto, OrderCto>
    {
        private readonly GroceryMapper _mapGrocery = new();
        public OrderCto? ToCto(OrderDto? from)
        {
            if (from == null) return null;

            OrderCto cto = new()
            {
                Id = from.Id,
                Created = from.CreationTime,
                Status = (int)from.Status
            };
            foreach (GroceryDto dto in from.Groceries)
            {
                cto.Groceries.Add(_mapGrocery.ToCto(from: dto));
            }

            return cto;
        }
        public OrderDto? ToDto(OrderCto? from)
        {
            if (from == null) return null;

            OrderDto dto = new()
            {
                Id = from.Id,
                Status = (EOrderStatus)from.Status,
                CreationTime = from.Created
            };
            foreach (GroceryCto cto in from.Groceries)
            {
                dto.Groceries.Add(_mapGrocery.ToDto(from: cto));
            }

            return dto;
        }
    }
}
