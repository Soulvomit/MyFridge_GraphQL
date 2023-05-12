using Client_Model.Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using Data_Model.Enum;
using System.Linq.Expressions;

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
        public Expression<Func<IngredientDto, IngredientCto>> ProjectToCto()
        {
            return dto => new IngredientCto
            {
                Id = dto.Id,
                Name = dto.Name,
                Unit = (int)dto.Unit,
                Category = dto.Category
            };
        }

        public Expression<Func<IngredientCto, IngredientDto>> ProjectToDto()
        {
            return cto => new IngredientDto
            {
                Id = cto.Id,
                Name = cto.Name,
                Unit = (EUnit)cto.Unit,
                Category = cto.Category
            };
        }
    }
}
