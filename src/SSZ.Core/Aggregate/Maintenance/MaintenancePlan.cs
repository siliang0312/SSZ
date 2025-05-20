using SSZ.Core.Aggregate.Maintenance.Events;

namespace SSZ.Core.Aggregate.Maintenance;

public class MaintenancePlan: EntityBase<Guid>, IAggregateRoot
{
  public Guid EquipmentId{get; private set;}
  public Guid MaintenanceItemId{get; private set;}
  public DateTime? LastDateTime{get; private set;}
  public DateTime NextDateTime{get; private set;}
  public MaintenancePlan(Guid equipmentId, Guid maintenanceItemId)
  {
    EquipmentId = Guard.Against.Default(equipmentId);
    MaintenanceItemId = Guard.Against.Default(maintenanceItemId);
    Id=Guid.NewGuid();
    RegisterDomainEvent(new PlanCreatedEvent(Id));
  }
  public void UpdateLastDateTime()
  {
    LastDateTime = DateTime.UtcNow;
  }
  public void UpdateNextDateTime(DateTime nextDateTime)
  {
    NextDateTime = nextDateTime;
  }
}
