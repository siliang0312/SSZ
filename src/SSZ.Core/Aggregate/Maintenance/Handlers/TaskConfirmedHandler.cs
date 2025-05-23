using SSZ.Core.Aggregate.Maintenance.Events;

namespace SSZ.Core.Aggregate.Maintenance.Handlers;

public class TaskConfirmedHandler: INotificationHandler<TaskConfirmedEvent>
{
  public async Task Handle(TaskConfirmedEvent notification, CancellationToken cancellationToken)
  {
    await Task.CompletedTask;
  }
}
