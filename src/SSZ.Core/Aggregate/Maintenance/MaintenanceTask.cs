using SSZ.Core.Aggregate.Maintenance.Exceptions;

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
    if (State != TaskState.Waiting) throw new MaintenanceException("只有被等待的任务才能被提交");
    ImageId = Guard.Against.Default(imageId);
    Duration = Guard.Against.NegativeOrZero(duration);
    State = TaskState.Submitted;
  }

  public void MarkConfirmed()
  {
    if (State != TaskState.Submitted) throw new MaintenanceException("只有已经提交的任务才能被确认");
    State = TaskState.Confirmed;
    CompleteTime = DateTime.UtcNow;
    
  }

  public void Reject(string reason)
  {
    if (State != TaskState.Submitted) throw new MaintenanceException("只有已经提交的任务才能被驳回");
    State = TaskState.Waiting;
    AuditOpinion = reason;
  }
}
