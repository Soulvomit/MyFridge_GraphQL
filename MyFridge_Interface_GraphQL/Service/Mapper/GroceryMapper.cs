using MyFridge_Interface_GraphQL.Service.Mapper.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Service.Mapper
{
    public class GroceryMapper : IMapperService<GroceryDto, GroceryCto>
    {
        private readonly IngredientAmountMapper _mapIngredientAmount = new();
        public GroceryCto? ToCto(GroceryDto? from)
        {
            if (from == null) return null;

            GroceryCto cto = new()
            {
                Id = from.Id,
                Brand = from.Brand,
                SalePrice = from.SalePrice,
                ItemIdentifier = from.ItemIdentifier,
                ImageUrl = from.ImageUrl,
                IngredientAmount = _mapIngredientAmount.ToCto(from.IngredientAmount)
            };
            return cto;
        }
        public GroceryDto? ToDto(GroceryCto? from)
        {
            if (from == null) return null;

            GroceryDto dto = new()
            {
                Id = from.Id,
                Brand = from.Brand,
                SalePrice = from.SalePrice,
                ItemIdentifier = from.ItemIdentifier,
                ImageUrl = from.ImageUrl,
                IngredientAmount = _mapIngredientAmount.ToDto(from.IngredientAmount)
            };

            return dto;
        }
    }
}
