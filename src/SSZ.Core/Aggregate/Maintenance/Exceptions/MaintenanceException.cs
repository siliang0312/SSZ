namespace SSZ.Core.Aggregate.Maintenance.Exceptions;

public class MaintenanceException: Exception
{
  public MaintenanceException(){}
  
  public MaintenanceException(string message)
  : base(message){}
}
