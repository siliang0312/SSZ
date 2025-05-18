namespace SSZ.Core.Aggregate.Maintenance;

public class MaintenanceCycleType:SmartEnum<MaintenanceCycleType>
{
  public static readonly MaintenanceCycleType Day = new(nameof(Day), 1);
  public static readonly MaintenanceCycleType Week = new(nameof(Week), 2);
  public static readonly MaintenanceCycleType Month = new(nameof(Month), 3);
  public MaintenanceCycleType(string name, int value) : base(name, value)
  {
    
  }
}
