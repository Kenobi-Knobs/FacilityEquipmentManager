using FacilityEquipmentManager.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using FacilityEquipmentManager.Services;
using FacilityEquipmentManager.Models.Entities;

namespace FacilityEquipmentManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract([FromBody] CreateContractDto contractDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contract newContract  = await _contractService.CreateContractAsync(contractDto);
            return Ok(newContract);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractDto>>> GetAllContracts()
        {
            IEnumerable<ContractDto> contracts = await _contractService.GetAllContractsAsync();
            return Ok(contracts);
        }
    }
}
