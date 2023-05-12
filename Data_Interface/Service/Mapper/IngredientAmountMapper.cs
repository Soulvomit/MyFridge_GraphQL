using Client_Model;
using Client_Model.Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;
using System.Linq.Expressions;

namespace Data_Interface.Service.Mapper
{
    public class IngredientAmountMapper : IMapperService<IngredientAmountDto, IngredientAmountCto>
    {
        private readonly IngredientMapper _mapIngredient = new();

        public IngredientAmountCto? ToCto(IngredientAmountDto? from)
        {
            if (from == null) return null;

            IngredientAmountCto cto = new()
            {
                Id = from.Id,
                Ingredient = _mapIngredient.ToCto(from.Ingredient),
                Amount = from.Amount,
                ExpirationDate = from.ExpirationDate
            };

            return cto;
        }
        public IngredientAmountDto? ToDto(IngredientAmountCto? from)
        {
            if (from == null) return null;

            IngredientAmountDto dto = new()
            {
                Id = from.Id,
                Ingredient = _mapIngredient.ToDto(from.Ingredient),
                Amount = from.Amount,
                ExpirationDate = from.ExpirationDate
            };

            return dto;
        }
        public Expression<Func<IngredientAmountDto, IngredientAmountCto>> ProjectToCto()
        {
            return dto => new IngredientAmountCto
            {
                Id = dto.Id,
                Amount = dto.Amount,
                ExpirationDate = dto.ExpirationDate,
                Ingredient = new IngredientCto
                {
                    Id = dto.Ingredient.Id,
                    Name = dto.Ingredient.Name,
                    Unit = (int)dto.Ingredient.Unit,
                    Category = dto.Ingredient.Category
                }
            };
        }
        public Expression<Func<IngredientAmountCto, IngredientAmountDto>> ProjectToDto()
        {
            return cto => new IngredientAmountDto
            {
                Id = cto.Id,
                Amount = cto.Amount,
                ExpirationDate = cto.ExpirationDate,
                Ingredient = new IngredientDto
                {
                    Id = cto.Id,
                    Name = cto.Ingredient.Name,
                    Unit = (EUnit)cto.Ingredient.Unit,
                    Category = cto.Ingredient.Category
                }
            };
        }
    }
}
