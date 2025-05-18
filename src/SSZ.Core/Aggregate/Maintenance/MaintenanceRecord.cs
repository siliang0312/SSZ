namespace SSZ.Core.Aggregate.Maintenance;

public class MaintenanceRecord:EntityBase
{
  public string MaintenanceItemName { get; private set; }
  public string MaintenanceItemContent { get; private set; }
  public string Duration { get; private set; }
  public string FilePath { get; private set; }
  public string EquipmentName { get; private set; }
  public string EquipmentTypeName { get; private set; }
  public DateTime CreateTime{get; private set;}
  public DateTime? CompleteTime{get; private set;}
  public DateTime RequestDateTime{get; private set;}
  public string? Feedback{get; private set;}
  public string? AuditOpinion{get; private set;}
  public MaintenanceRecord(string maintenanceItemName, string maintenanceItemContent, string duration, string filePath, string equipmentName, string equipmentTypeName, DateTime createTime, DateTime? completeTime, DateTime requestDateTime,string? feedback, string? auditOpinion)
  {
    MaintenanceItemName = Guard.Against.NullOrWhiteSpace(maintenanceItemName);
    MaintenanceItemContent = Guard.Against.NullOrWhiteSpace(maintenanceItemContent);
    Duration = Guard.Against.NullOrWhiteSpace(duration);
    FilePath = Guard.Against.NullOrWhiteSpace(filePath);
    EquipmentName = Guard.Against.NullOrWhiteSpace(equipmentName);
    EquipmentTypeName = Guard.Against.NullOrWhiteSpace(equipmentTypeName);
    CreateTime = Guard.Against.Default(createTime);
    CompleteTime = completeTime;
    RequestDateTime = Guard.Against.Default(requestDateTime);
    Feedback = feedback;
    AuditOpinion = auditOpinion;
  }

  public bool IsOverdue()
  {
    return CompleteTime>RequestDateTime;
  }
}
