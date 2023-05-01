using Data_Model.Abstract;
using Data_Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Data_Model
{
    public class IngredientDto : SimpleDatabaseItem
    {
        //add category to this
        [Required, MaxLength(50)]
        public required string Name { get; set; }
        [Required]
        public required EUnit Unit { get; set; } = EUnit.Piece;
        [MaxLength(50)]
        public string? Category { get; set; } = string.Empty;
    }
}
