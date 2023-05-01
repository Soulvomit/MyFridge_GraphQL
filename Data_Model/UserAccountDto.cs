using Data_Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Model
{
    public class UserAccountDto : AccountDto
    {
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public virtual AddressDto? Address { get; set; }
        [Required, MaxLength(100), EmailAddress]
        public required string? Email { get; set; }
        [Required]
        public required ulong PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public virtual ICollection<IngredientAmountDto> IngredientAmounts { get; set; } = new List<IngredientAmountDto>();
    }
}