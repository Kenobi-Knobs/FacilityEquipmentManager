using FacilityEquipmentManager.Models.Entities;

namespace FacilityEquipmentManager.Services
{
    public interface IContractQueue
    {
        void Enqueue(Contract contract);
        bool TryDequeue(out Contract contract);
    }
}
