using MyFridge_Interface_GraphQL.Service.Mapper.Interface;
using MyFridge_Library_Client_MAUI.ClientModel;
using MyFridge_Library_Data.DataModel;

namespace MyFridge_Interface_GraphQL.Service.Mapper
{
    public class RecipeMapper : IMapperService<RecipeDto, RecipeCto>
    {
        private readonly IngredientAmountMapper _mapIngredientAmount = new();
        public RecipeCto? ToCto(RecipeDto? from)
        {
            if (from == null) return null;

            RecipeCto cto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Method = from.Method,
                ImageUrl = from.ImageUrl
            };
            foreach (IngredientAmountDto dto in from.IngredientAmounts)
            {
                cto.IngredientAmounts.Add(_mapIngredientAmount.ToCto(from: dto));
            }

            return cto;
        }
        public RecipeDto? ToDto(RecipeCto? from)
        {
            if (from == null) return null;

            RecipeDto dto = new()
            {
                Id = from.Id,
                Name = from.Name,
                Method = from.Method,
                ImageUrl = from.ImageUrl
            };

            foreach (IngredientAmountCto cto in from.IngredientAmounts)
            {
                dto.IngredientAmounts.Add(_mapIngredientAmount.ToDto(from: cto));
            }

            return dto;
        }
    }
}
