using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacilityEquipmentManager.Models.Entities
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string FacilityCode { get; set; }
        [ForeignKey("FacilityCode")]
        public Facility Facility { get; set; }

        [Required]
        public required string EquipmentTypeCode { get; set; }
        [ForeignKey("EquipmentTypeCode")]
        public EquipmentType EquipmentType { get; set; }

        public int Quantity { get; set; }
    }
}
