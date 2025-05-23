using SSZ.Core.Aggregate.Maintenance.Events;

namespace SSZ.Core.Aggregate.Maintenance.Handlers;

public class TaskConfirmedHandler(ILogger<TaskConfirmedHandler> logger): INotificationHandler<TaskConfirmedEvent>
{
  public async Task Handle(TaskConfirmedEvent notification, CancellationToken cancellationToken)
  {
    //TODO:发送任务完成通知
    logger.LogWarning("以下维护任务已完成：{taskIds}",notification.Tasks);
    
    
    //TODO:生成任务记录
    await Task.CompletedTask;
  }
}
