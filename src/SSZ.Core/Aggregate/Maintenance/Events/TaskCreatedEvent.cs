namespace SSZ.Core.Aggregate.Maintenance.Events;

public sealed class TaskCreatedEvent(Guid planId,Guid taskId) : DomainEventBase
{
  public Guid PlanId { get; init; } = planId;
  public Guid TaskId { get; init; } = taskId;
};

