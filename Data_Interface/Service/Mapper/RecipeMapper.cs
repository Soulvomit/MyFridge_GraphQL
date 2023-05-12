using Client_Model.Model;
using Data_Interface.Service.Mapper.Interface;
using Data_Model;
using System.Linq.Expressions;

namespace Data_Interface.Service.Mapper
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
        public Expression<Func<RecipeDto, RecipeCto>> ProjectToCto()
        {
            var mappingExpression = _mapIngredientAmount.ProjectToCto();
            return dto => new RecipeCto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Method = dto.Method,
                ImageUrl = dto.ImageUrl,
                IngredientAmounts = dto.IngredientAmounts.AsQueryable().Select(mappingExpression).ToList()
            };
        }

        public Expression<Func<RecipeCto, RecipeDto>> ProjectToDto()
        {
            var mappingExpression = _mapIngredientAmount.ProjectToDto();
            return dto => new RecipeDto()
            {
                Id = dto.Id,
                Name = dto.Name,
                Method = dto.Method,
                ImageUrl = dto.ImageUrl,
                IngredientAmounts = dto.IngredientAmounts.AsQueryable().Select(mappingExpression).ToList()
            };
        }
    }
}
