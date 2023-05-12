using Client_Model.Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;
using System.Linq.Expressions;

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
                CreationTime = from.Created,
                Status = (EOrderStatus)from.Status
            };
            foreach (GroceryCto cto in from.Groceries)
            {
                dto.Groceries.Add(_mapGrocery.ToDto(from: cto));
            }

            return dto;
        }
        public Expression<Func<OrderDto, OrderCto>> ProjectToCto()
        {
            var mappingExpression = _mapGrocery.ProjectToCto();
            return dto => new OrderCto()
            {
                Id = dto.Id,
                Created = dto.CreationTime,
                Status = (int)dto.Status,
                Groceries = dto.Groceries.AsQueryable().Select(mappingExpression).ToList()
            };
        }

        public Expression<Func<OrderCto, OrderDto>> ProjectToDto()
        {
            var mappingExpression = _mapGrocery.ProjectToDto();
            return cto => new OrderDto()
            {
                Id = cto.Id,
                CreationTime = cto.Created,
                Status = (EOrderStatus)cto.Status,
                Groceries = cto.Groceries.AsQueryable().Select(mappingExpression).ToList()
            };
        }
    }
}
