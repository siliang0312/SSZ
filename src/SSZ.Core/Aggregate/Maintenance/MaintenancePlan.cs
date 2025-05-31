using SSZ.Core.Aggregate.Equipment;
using SSZ.Core.Aggregate.Maintenance.Events;
using SSZ.Core.Aggregate.Maintenance.Exceptions;

namespace SSZ.Core.Aggregate.Maintenance;

public class MaintenancePlan: EntityBase<Guid>, IAggregateRoot
{
  public Guid EquipmentId{get; private set;}
  public Guid MaintenanceItemId{get; private set;}
  public DateTime? LastDateTime{get; private set;}
  public DateTime NextDateTime{get; private set;}
  public bool IsActive{get; private set;}
  public MaintenancePlan(Guid equipmentId, Guid maintenanceItemId)
  {
    EquipmentId = Guard.Against.Default(equipmentId);
    MaintenanceItemId = Guard.Against.Default(maintenanceItemId);
    Id=Guid.NewGuid();
    IsActive= true;
    // RegisterDomainEvent(new PlanCreatedEvent(Id));
  }
  public void UpdateLastDateTime()
  {
    LastDateTime = DateTime.UtcNow.Date;
  }
  public void UpdateNextDateTime(DateTime nextDateTime)
  {
    NextDateTime = nextDateTime;
  }

  public void ClearNextDateTime()
  {
    NextDateTime  = DateTime.MaxValue;
  }
  public void SetActiveBasedOnEquipStatus(EquipmentStatus newState)
  {
    if (newState == EquipmentStatus.Stop)
      SetActive(false);
    else if (newState == EquipmentStatus.Normal)
      SetActive(true);
    else
      throw new MaintenanceException(newState);
  }
  public void SetActive(bool isActive)
  {
    IsActive = isActive;
  }
}
