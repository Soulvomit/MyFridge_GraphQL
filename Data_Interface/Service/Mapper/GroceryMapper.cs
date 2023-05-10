using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;
using System.Linq.Expressions;

namespace Data_Interface.Service.Mapper
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

        public Expression<Func<GroceryDto, GroceryCto>> ProjectToCto()
        {
            return dto => new GroceryCto
            {
                Id = dto.Id,
                Brand = dto.Brand,
                SalePrice = dto.SalePrice,
                ItemIdentifier = dto.ItemIdentifier,
                ImageUrl = dto.ImageUrl,
                IngredientAmount = new IngredientAmountCto
                {
                    Id = dto.IngredientAmount.Id,
                    Amount = dto.IngredientAmount.Amount,
                    ExpirationDate = dto.IngredientAmount.ExpirationDate,
                    Ingredient = new IngredientCto
                    {
                        Id = dto.IngredientAmount.Id,
                        Name = dto.IngredientAmount.Ingredient.Name,
                        Unit = (int)dto.IngredientAmount.Ingredient.Unit,
                        Category = dto.IngredientAmount.Ingredient.Category
                    }
                }
            };
        }

        public Expression<Func<GroceryCto, GroceryDto>> ProjectToDto()
        {
            return cto => new GroceryDto
            {
                Id = cto.Id,
                Brand = cto.Brand,
                SalePrice = cto.SalePrice,
                ItemIdentifier = cto.ItemIdentifier,
                ImageUrl = cto.ImageUrl,
                IngredientAmount = new IngredientAmountDto
                {
                    Id = cto.IngredientAmount.Id,
                    Amount = cto.IngredientAmount.Amount,
                    ExpirationDate = cto.IngredientAmount.ExpirationDate,
                    Ingredient = new IngredientDto
                    {
                        Id = cto.IngredientAmount.Id,
                        Name = cto.IngredientAmount.Ingredient.Name,
                        Unit = (EUnit)cto.IngredientAmount.Ingredient.Unit,
                        Category = cto.IngredientAmount.Ingredient.Category
                    }
                }
            };
        }
    }
}
