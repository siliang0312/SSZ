namespace SSZ.Core.Aggregate.Maintenance.Events;
[Obsolete("弃用该领域事件")]
public sealed class PlanCreatedEvent(Guid id) : DomainEventBase
{
  public Guid PlanId { get; init; } = id;
};
