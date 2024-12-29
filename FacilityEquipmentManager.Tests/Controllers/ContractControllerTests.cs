using FacilityEquipmentManager.Controllers;
using FacilityEquipmentManager.Models.DTOs;
using FacilityEquipmentManager.Models.Entities;
using FacilityEquipmentManager.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FacilityEquipmentManager.Tests.Controllers
{
    public class ContractControllerTests
    {
        private readonly Mock<IContractService> _mockContractService;
        private readonly ContractsController _controller;

        public ContractControllerTests()
        {
            _mockContractService = new Mock<IContractService>();
            _controller = new ContractsController(_mockContractService.Object);
        }

        [Fact]
        public async Task CreateContract_ShouldReturnOk_WhenValidRequest()
        {
            // Arrange
            var contractDto = new CreateContractDto
            {
                FacilityCode = "Facility1",
                EquipmentTypeCode = "Equipment1",
                EquipmentQuantity = 10
            };

            var contract = new Contract
            {
                FacilityCode = "Facility1",
                EquipmentTypeCode = "Equipment1",
                Quantity = 10
            };

            _mockContractService.Setup(service => service.CreateContractAsync(contractDto))
                .ReturnsAsync(contract);

            // Act
            var result = await _controller.CreateContract(contractDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedContract = Assert.IsType<Contract>(okResult.Value);
            Assert.Equal(contract.FacilityCode, returnedContract.FacilityCode);
            Assert.Equal(contract.Quantity, returnedContract.Quantity);
        }

        [Fact]
        public async Task CreateContract_InsufficientFacilityArea_ReturnsInvalidOperationException()
        {
            // Arrange
            var contractDto = new CreateContractDto
            {
                FacilityCode = "Facility1",
                EquipmentTypeCode = "Equipment1",
                EquipmentQuantity = 10
            };

            _mockContractService.Setup(service => service.CreateContractAsync(contractDto))
                .ThrowsAsync(new InvalidOperationException("Facility does not have enough area to store the equipment."));

            // Act
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _controller.CreateContract(contractDto));

            // Assert
            Assert.Equal("Facility does not have enough area to store the equipment.", exception.Message);
        }

        [Fact]
        public async Task CreateContract_EquipmentTypeNotFound_ThrowsKeyNotFoundException()
        {
            // Arrange
            var contractDto = new CreateContractDto
            {
                FacilityCode = "Facility1",
                EquipmentTypeCode = "InvalidEquipment",
                EquipmentQuantity = 10
            };

            _mockContractService.Setup(service => service.CreateContractAsync(contractDto))
                .ThrowsAsync(new KeyNotFoundException($"Equipment type {contractDto.EquipmentTypeCode} not found."));

            // Act
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _controller.CreateContract(contractDto));

            // Assert
            Assert.Equal($"Equipment type {contractDto.EquipmentTypeCode} not found.", exception.Message);
        }

        [Fact]
        public async Task GetAllContracts_ValidData_ReturnsContractDtoList()
        {
            // Arrange
            var contractDtos = new List<ContractDto>
            {
                new ContractDto { FacilityName = "Facility1", EquipmentTypeName = "Type1", EquipmentQuantity = 10 }
            };

            _mockContractService.Setup(service => service.GetAllContractsAsync())
                .ReturnsAsync(contractDtos);

            // Act
            var result = await _controller.GetAllContracts();

            // Assert
            OkObjectResult okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            IEnumerable<ContractDto> returnedContracts = Assert.IsType<List<ContractDto>>(okObjectResult.Value);

            Assert.Equal(contractDtos.Count, returnedContracts.Count());
            Assert.Equal(contractDtos.First().FacilityName, returnedContracts.First().FacilityName);
            Assert.Equal(contractDtos.First().EquipmentTypeName, returnedContracts.First().EquipmentTypeName);
            Assert.Equal(contractDtos.First().EquipmentQuantity, returnedContracts.First().EquipmentQuantity);
        }
    }
}
