using Data_Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Model
{
    public class GroceryDto : DatabaseItem
    {
        [Required]
        public int IngredientAmountId { get; set; }
        [Required, ForeignKey("IngredientAmountId")]
        public required virtual IngredientAmountDto? IngredientAmount { get; set; }
        [MaxLength(50)]
        public string? Brand { get; set; } = string.Empty;
        public float SalePrice { get; set; } = 0;
        [MaxLength(50)]
        public string? ItemIdentifier { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? ImageUrl { get; set; } = string.Empty;
    }
}