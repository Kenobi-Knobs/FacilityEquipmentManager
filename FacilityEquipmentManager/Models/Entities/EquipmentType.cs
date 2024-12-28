using System.ComponentModel.DataAnnotations;

namespace FacilityEquipmentManager.Models.Entities
{
    public class EquipmentType
    {
        [Key]
        public required string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 characters.")]
        public required string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Area must be greater than 0.")]
        public required int Area { get; set; }
    }
}
