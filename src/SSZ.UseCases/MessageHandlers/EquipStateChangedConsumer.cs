using SSZ.Core.Aggregate.Equipment;
using SSZ.Core.Aggregate.Maintenance;
using SSZ.Core.Aggregate.Maintenance.Specifications;

namespace SSZ.UseCases.MessageHandlers;

public class EquipStateChangedConsumer(IRepository<MaintenancePlan> repository) 
{
  public async Task Consume(EquipStateChangedIntegrationEvent eventData)
  {
    var specification = new GetPlansByEquipIdSpec(eventData.EquipId);
    var plans = await repository.ListAsync(specification);
    plans.ForEach(a=>a.SetActiveBasedOnEquipStatus(eventData.State));
    await repository.SaveChangesAsync();
  }
}
