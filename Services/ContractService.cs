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

    }
}
