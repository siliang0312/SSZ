using SSZ.Core.Aggregate.Maintenance.Events;

namespace SSZ.Core.Aggregate.Maintenance.Handlers;

public class PlanCreatedHandler(ILogger<PlanCreatedHandler> logger
  ,IRepository<MaintenancePlan> repository,IRepository<MaintenanceItem> itemRepository) : INotificationHandler<PlanCreatedEvent>
{
  public async Task Handle(PlanCreatedEvent domainEvent, CancellationToken cancellationToken)
  {
    logger.LogInformation("Handling MaintenancePlan Created event for {planId}", domainEvent.PlanId);
    
    var plan=await repository.GetByIdAsync(domainEvent.PlanId, cancellationToken);
    var item=await itemRepository.GetByIdAsync(plan!.EquipmentId, cancellationToken);
    
   var nextDate= item!.MaintenanceCycle!.GetNextDate(DateTime.UtcNow).Date;
   plan.UpdateNextDateTime(nextDate);
   await repository.UpdateAsync(plan, cancellationToken);
  }
}
