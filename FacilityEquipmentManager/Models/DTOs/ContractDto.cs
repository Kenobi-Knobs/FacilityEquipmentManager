namespace FacilityEquipmentManager.Models.DTOs
{
    public class ContractDto
    {
        public required string FacilityName { get; set; }
        public required string EquipmentTypeName { get; set; }
        public required int EquipmentQuantity { get; set; }
    }
}
