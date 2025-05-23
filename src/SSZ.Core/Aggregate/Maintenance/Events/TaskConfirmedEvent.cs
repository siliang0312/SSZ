namespace SSZ.Core.Aggregate.Maintenance.Events;

public class TaskConfirmedEvent(IEnumerable<MaintenanceTask> tasks):DomainEventBase
{
  public IEnumerable<MaintenanceTask> Tasks { get; set; } = tasks;
}
