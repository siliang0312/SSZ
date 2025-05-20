namespace SSZ.Core.Aggregate.Maintenance.Events;

internal sealed class PlanCreatedEvent(Guid id) : DomainEventBase
{
  public Guid PlanId { get; init; } = id;
};
