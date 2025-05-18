namespace SSZ.Core.Aggregate.Maintenance;

public class MaintenanceTask: EntityBase<Guid>, IAggregateRoot
{
  public Guid EquipmentId{get; private set;}
  public Guid MaintenanceItemId{get; private set;}
  public Guid MaintenancePlanId{get; private set;}
  public DateTime RequestDateTime{get; private set;}
  public DateTime CreateTime{get; private set;}
  public DateTime? CompleteTime{get; private set;}
  public TaskState State{get; private set;}
  public string? Feedback{get; private set;}
  public string? AuditOpinion{get; private set;}
  public Guid ImageId{get; private set;}
  public int Duration{get; private set;}
  public MaintenanceTask(Guid equipmentId, Guid maintenanceItemId, Guid maintenancePlanId, DateTime requestDateTime, DateTime createTime)
  {
    EquipmentId = Guard.Against.Default(equipmentId);
    MaintenanceItemId = Guard.Against.Default(maintenanceItemId);
    MaintenancePlanId = Guard.Against.Default(maintenancePlanId);
    RequestDateTime = Guard.Against.Default(requestDateTime);
    CreateTime = Guard.Against.Default(createTime);
    State  = TaskState.Waiting;
  }
  public void MarkSubmitted(Guid imageId, int duration)
  {
    ImageId = Guard.Against.Default(imageId);
    Duration = Guard.Against.NegativeOrZero(duration);
    State = TaskState.Submitted;
  }

  public void MarkConfirmed()
  {
    State = TaskState.Confirmed;
    CompleteTime = DateTime.UtcNow;
    
  }

  public void Reject(string reason)
  {
    State = TaskState.Waiting;
    AuditOpinion = reason;
  }
}
