using FacilityEquipmentManager.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FacilityEquipmentManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateContract([FromBody] CreateContractDto contractDto)
        {
            // TODO: Implement logic for creating a new contract
            return Ok();
        }

        [HttpGet]
        public IActionResult GetContracts()
        {
            // TODO: Implement logic for retrieving the list of contracts
            return Ok();
        }
    }
}
