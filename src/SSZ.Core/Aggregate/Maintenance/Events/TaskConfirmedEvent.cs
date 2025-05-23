namespace SSZ.Core.Aggregate.Maintenance.Events;

public class TaskConfirmedEvent(IEnumerable<Guid> taskIds):DomainEventBase
{
  public IEnumerable<Guid> TaskIds { get; set; } = taskIds;
}
