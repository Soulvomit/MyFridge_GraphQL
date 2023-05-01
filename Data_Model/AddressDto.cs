using Data_Model.Abstract;
using Data_Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Data_Model
{
    public class AddressDto : DatabaseItem
    {
        [MaxLength(50)]
        public string? Street { get; set; }
        [MaxLength(50)]
        public string? Extension { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? State { get; set; }
        [MaxLength(50)]
        public string? ZipCode { get; set; }
        public ECountry Country { get; set; } = ECountry.UnitedStates;
    }
}