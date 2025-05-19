using System.ComponentModel.DataAnnotations;

namespace SSZ.Core.Aggregate.Maintenance;

public class MaintenanceItem:EntityBase<Guid>,IAggregateRoot
{
  public string? Name { get; private set; }
  public string? Content { get; private set; }
  public Guid EquipmentTypeId { get; private set; }
  public MaintenanceCycle? MaintenanceCycle { get; private set; } 
  
  public MaintenanceItem(string name, string content, Guid equipmentTypeId,  MaintenanceCycle maintenanceCycle)
  {
    Name = Guard.Against.NullOrWhiteSpace(name, nameof(name));
    Content = Guard.Against.NullOrWhiteSpace(content, nameof(content));
    EquipmentTypeId = Guard.Against.Default(equipmentTypeId, nameof(equipmentTypeId));
    MaintenanceCycle = Guard.Against.Null(maintenanceCycle, nameof(maintenanceCycle));
  }

  private MaintenanceItem()
  {
    
  }

  
}
