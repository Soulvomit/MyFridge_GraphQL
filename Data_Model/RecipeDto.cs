using Data_Model.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Data_Model
{
    public class RecipeDto : DatabaseItem
    {
        [Required, MaxLength(50)]
        public required string Name { get; set; }
        public virtual ICollection<IngredientAmountDto> IngredientAmounts { get; set; } = new List<IngredientAmountDto>();
        [MaxLength(1800)]
        public string? Method { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? ImageUrl { get; set; } = string.Empty;

    }
}