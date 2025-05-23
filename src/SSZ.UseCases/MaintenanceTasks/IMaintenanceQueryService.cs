namespace SSZ.UseCases.MaintenanceTasks;

public interface IMaintenanceQueryService
{
  Task<IEnumerable<MaintenanceTaskDto>> GetTaskByEquipCode(string equipmentCode, int state);
}
