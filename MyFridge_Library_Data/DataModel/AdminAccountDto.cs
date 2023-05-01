using System.ComponentModel.DataAnnotations;

namespace MyFridge_Library_Data.DataModel
{
    public class AdminAccountDto : Abstract.AccountDto
    {
        [Required, MaxLength(100)]
        public required string EmployeeNumber { get; set; }
    }
}
