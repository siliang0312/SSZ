using SSZ.Core.Aggregate.Maintenance;
using SSZ.Infrastructure.Data.Repositories;

namespace SSZ.UseCases.MaintenancePlans;

public class CreateMaintenancePlanHandler( IMaintenanceRepository maintenanceRepository): ICommandHandler<CreateMaintenancePlanCommand,Result>
{
  public async Task<Result> Handle(CreateMaintenancePlanCommand request, CancellationToken cancellationToken)
  {
    var equipAndItem =await maintenanceRepository.GetEquipAndItemAsync();
    List<MaintenancePlan> plans = [];
    plans.AddRange(equipAndItem.Select(ei => new MaintenancePlan(ei.EquipmentId, ei.MaintenanceItemId)));
    await maintenanceRepository.InsertPlans(plans);
    return Result.Success();
  }
}
