using System.ComponentModel.DataAnnotations;

namespace FacilityEquipmentManager.Models.Entities
{
    public class Facility
    {
        [Key]
        [MaxLength(30, ErrorMessage = "Code must be less than 30 characters.")]
        public required string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 characters.")]
        public required string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "StandardArea must be greater than 0.")]
        public required int StandardArea { get; set; }
    }
}
