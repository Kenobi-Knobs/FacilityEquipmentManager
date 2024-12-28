using FacilityEquipmentManager.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using FacilityEquipmentManager.Services;

namespace FacilityEquipmentManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly ContractService _contractService;

        public ContractsController(ContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        public IActionResult CreateContract([FromBody] CreateContractDto contractDto)
        {
            // TODO: Implement logic for creating a new contract
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDto>>> GetAllContracts()
        {
            IEnumerable<ContractDto> contracts = await _contractService.GetAllContractsAsync();
            return Ok(contracts);
        }
    }
}
