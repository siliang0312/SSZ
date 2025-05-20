using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Dtos;

namespace SSZ.Infrastructure.Data.Repositories;

public interface IMaintenanceRepository
{
  Task<IEnumerable<EquipAndItemDto>> GetEquipAndItemAsync();
  Task InsertPlans(List<MaintenancePlan> plans);
}
