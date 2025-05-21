namespace SSZ.Core.Aggregate.Maintenance.Events;

public sealed class PlanCreatedEvent(Guid id) : DomainEventBase
{
  public Guid PlanId { get; init; } = id;
};
