using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Core.Interfaces;

public interface IMaintenanceTaskService
{
  Task ConfirmTask(List<MaintenanceTask> tasks);
}
