using FacilityEquipmentManager.Models.Entities;
using System.Collections.Concurrent;

namespace FacilityEquipmentManager.Services
{
    public class ContractQueue : IContractQueue
    {
        private readonly ConcurrentQueue<Contract> _queue = new();

        public void Enqueue(Contract contract)
        {
            _queue.Enqueue(contract);
        }

        public bool TryDequeue(out Contract contract)
        {
            return _queue.TryDequeue(out contract);
        }
    }
}
