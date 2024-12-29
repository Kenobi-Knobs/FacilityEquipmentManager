using FacilityEquipmentManager.Models.DTOs;
using FacilityEquipmentManager.Models.Entities;

namespace FacilityEquipmentManager.Services
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDto>> GetAllContractsAsync();
        Task<Contract> CreateContractAsync(CreateContractDto contractDto);
    }
}
