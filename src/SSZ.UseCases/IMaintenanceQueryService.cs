using SSZ.UseCases.MaintenanceTasks;

namespace SSZ.UseCases;

public interface IMaintenanceQueryService
{
  Task<IEnumerable<MaintenanceTaskDto>> GetTaskByEquipCode(string equipmentCode, int state);
  Task<IEnumerable<EquipAndItemDto>> GetEquipAndItemAsync();
  
}
