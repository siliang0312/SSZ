using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.UseCases.MaintenanceTasks;

public class GetByEquipCodeHandler(IRepository<MaintenanceTask> taskRepo,IRepository<MaintenanceItem>itemRepo):  IQueryHandler<GetByEquipCodeQuery, IEnumerable<MaintenanceTaskDto>>
{
  public Task<IEnumerable<MaintenanceTaskDto>> Handle(GetByEquipCodeQuery request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}
