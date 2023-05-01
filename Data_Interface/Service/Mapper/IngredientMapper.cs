using Client_Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;

namespace Data_Interface.Service.Mapper
{
    public class IngredientMapper : IMapperService<IngredientDto, IngredientCto>
    {
        public IngredientCto? ToCto(IngredientDto? from)
        {
            if (from == null) return null;

            IngredientCto cto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Unit = (int)from.Unit,
                Category = from.Category
            };

            return cto;
        }
        public IngredientDto? ToDto(IngredientCto? from)
        {
            if (from == null) return null;

            IngredientDto dto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Unit = (EUnit)from.Unit,
                Category = from.Category,
            };

            return dto;
        }
    }
}
