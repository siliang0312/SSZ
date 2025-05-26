using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Core.Interfaces;

public interface IMaintenanceRepository
{
  Task InsertPlans(List<MaintenancePlan> plans);
}
