using Data_Model.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Data_Model
{
    public class AdminAccountDto : AccountDto
    {
        [Required, MaxLength(100)]
        public required string EmployeeNumber { get; set; }
    }
}
