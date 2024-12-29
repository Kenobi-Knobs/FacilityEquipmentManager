namespace FacilityEquipmentManager.Services
{
    public class ContractBackgroundProcessor : BackgroundService
    {
        private readonly IContractQueue _contractQueue;
        private readonly ILogger<ContractBackgroundProcessor> _logger;

        public ContractBackgroundProcessor(IContractQueue contractQueue, ILogger<ContractBackgroundProcessor> logger)
        {
            _contractQueue = contractQueue;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("ContractBackgroundProcessor started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                if (_contractQueue.TryDequeue(out var contract))
                {
                    try
                    {
                        _logger.LogInformation($"Processing contract with ID: {contract.Id}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error processing contract with ID: {contract.Id}");
                    }
                }
                else
                {
                    await Task.Delay(500, stoppingToken);
                }
            }

            _logger.LogInformation("ContractBackgroundProcessor stopped.");
        }
    }
}
