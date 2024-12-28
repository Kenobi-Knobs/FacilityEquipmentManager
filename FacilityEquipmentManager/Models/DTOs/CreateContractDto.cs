using System.ComponentModel.DataAnnotations;

namespace FacilityEquipmentManager.Models.DTOs
{
    public class CreateContractDto
    {
        [Required(ErrorMessage = "FacilityCode is required.")]
        [MaxLength(30, ErrorMessage = "FacilityCode must be less than 30 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "FacilityCode must contain only letters and numbers.")]
        public required string FacilityCode { get; set; }

        [Required(ErrorMessage = "EquipmentTypeCode is required.")]
        [MaxLength(30, ErrorMessage = "EquipmentTypeCode must be less than 30 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "EquipmentTypeCode must contain only letters and numbers.")]
        public required string EquipmentTypeCode { get; set; }

        [Required(ErrorMessage = "EquipmentQuantity is required.")]
        [Range(1, 1000, ErrorMessage = "EquipmentQuantity must be between 1 and 1000.")]
        public int EquipmentQuantity { get; set; }
    }
}
