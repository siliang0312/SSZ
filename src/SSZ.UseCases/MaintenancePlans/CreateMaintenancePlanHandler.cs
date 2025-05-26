using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Interfaces;

namespace SSZ.UseCases.MaintenancePlans;

public class CreateMaintenancePlanHandler( IMaintenanceRepository maintenanceRepository
  ,IRepository<MaintenanceItem> itemRepository,IMaintenanceQueryService  queryService): ICommandHandler<CreateMaintenancePlanCommand,Result>
{
  public async Task<Result> Handle(CreateMaintenancePlanCommand request, CancellationToken cancellationToken)
  {
    var items =await itemRepository.ListAsync(cancellationToken);
    var equipAndItem =await queryService.GetEquipAndItemAsync();
    List<MaintenancePlan> plans = [];
    foreach (var ei in equipAndItem)
    {
      MaintenancePlan plan = new(ei.EquipmentId, ei.MaintenanceItemId);
      var item=items.FirstOrDefault(i => i.Id == ei.MaintenanceItemId);
      if(item==null)continue;
      plan.UpdateNextDateTime(item.MaintenanceCycle!.GetNextDate(DateTime.UtcNow));
      plans.Add(plan);
    }
    await maintenanceRepository.InsertPlans(plans);
    return Result.Success();
  }
}
