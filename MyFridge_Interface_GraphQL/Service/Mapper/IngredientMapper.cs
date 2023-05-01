using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel.Enum;
using MyFridge_Library_Data.DataModel;
using MyFridge_Interface_GraphQL.Service.Mapper.Interface;

namespace MyFridge_Interface_GraphQL.Service.Mapper
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
