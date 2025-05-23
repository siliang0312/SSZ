using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.UseCases.MaintenanceTasks;

public class GetByEquipCodeHandler(IMaintenanceQueryService queryService):  IQueryHandler<GetByEquipCodeQuery, Result<IEnumerable<MaintenanceTaskDto>>>
{
  public async Task<Result<IEnumerable<MaintenanceTaskDto>>> Handle(GetByEquipCodeQuery request, CancellationToken cancellationToken)
  {
    var result=await  queryService.GetTaskByEquipCode(request.EquipmentCode, request.State);
    return Result.Success(result);
  }
}
