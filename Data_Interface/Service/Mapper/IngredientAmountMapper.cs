using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;

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
    }
}
