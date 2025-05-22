using SSZ.Core.Aggregate.Maintenance.Events;

namespace SSZ.Core.Aggregate.Maintenance.Handlers;

public class TaskCreatedHandler(IRepository<MaintenancePlan> planRepo,ILogger<TaskCreatedHandler> logger):  INotificationHandler<TaskCreatedEvent>
{
  public async Task Handle(TaskCreatedEvent notification, CancellationToken cancellationToken)
  {
   var plan= await planRepo.GetByIdAsync(notification.PlanId, cancellationToken);
   plan!.ClearNextDateTime();
   plan.UpdateLastDateTime();
   await planRepo.SaveChangesAsync(cancellationToken);
    
   //TODO:发送维护通知
   logger.LogWarning("维护任务{TaskId}已经生成",  notification.TaskId);
  }
}
