using SSZ.Core.Aggregate.Equipment;

namespace SSZ.Core.Aggregate.Maintenance.Exceptions;

public class MaintenanceException: Exception
{
  public MaintenanceException(){}
  
  public MaintenanceException(string message)
  : base(message){}
  
  public MaintenanceException(EquipmentStatus state) : base($"Unsupported equipment status: {state.Name}")
  {
  }
}
