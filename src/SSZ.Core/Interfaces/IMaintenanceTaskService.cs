namespace SSZ.Core.Interfaces;

public interface IMaintenanceTaskService
{
  Task ConfirmTask(List<Guid> planIds,List<Guid> taskIds);
}
