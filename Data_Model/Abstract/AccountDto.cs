using System.ComponentModel.DataAnnotations;

namespace Data_Model.Abstract
{
    public abstract class AccountDto : DatabaseItem
    {
        [MaxLength(50), Required]
        public required string FirstName { get; set; }
        [MaxLength(50), Required]
        public required string LastName { get; set; }
        [MaxLength(30), Required]
        public required string Password { get; set; }
    }
}