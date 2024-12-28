using FacilityEquipmentManager.Data;
using FacilityEquipmentManager.Models.DTOs;
using FacilityEquipmentManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityEquipmentManager.Services
{
    public class ContractService
    {
        private readonly ApplicationDbContext _context;

        public ContractService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContractDto>> GetAllContractsAsync()
        {
            List<ContractDto> contracts = await _context.Contracts
                .Include(c => c.Facility)
                .Include(c => c.EquipmentType)
                .Select(c => new ContractDto
                {
                    FacilityName = c.Facility.Name,
                    EquipmentTypeName = c.EquipmentType.Name,
                    EquipmentQuantity = c.Quantity
                })
                .ToListAsync();

            return contracts;
        }

        public async Task<Contract> CreateContractAsync(CreateContractDto contractDto)
        {
            Facility facility = await _context.Facilities
                .FirstOrDefaultAsync(f => f.Code == contractDto.FacilityCode)
                ?? throw new KeyNotFoundException($"Facility {contractDto.FacilityCode} not found.");
            
            EquipmentType equipmentType = await _context.EquipmentTypes
                .FirstOrDefaultAsync(et => et.Code == contractDto.EquipmentTypeCode)
                ?? throw new KeyNotFoundException($"Equipment type {contractDto.EquipmentTypeCode} not found.");

            int totalRequiredArea = equipmentType.Area * contractDto.EquipmentQuantity;
            if (totalRequiredArea > facility.StandardArea)
            {
                throw new InvalidOperationException("Facility does not have enough area to store the equipment.");
            }

            Contract contract = new Contract
            {
                FacilityCode = facility.Code,
                EquipmentTypeCode = equipmentType.Code,
                Quantity = contractDto.EquipmentQuantity
            };

            _context.Contracts.Add(contract);
            facility.StandardArea -= totalRequiredArea;
            await _context.SaveChangesAsync();

            return contract;
        }
    }
}
