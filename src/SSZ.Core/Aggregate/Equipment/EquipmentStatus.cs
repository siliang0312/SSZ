namespace SSZ.Core.Aggregate.Equipment;

public class EquipmentStatus : SmartEnum<EquipmentStatus>
{
  public static readonly EquipmentStatus Normal = new(nameof(Normal), 1);
  public static readonly EquipmentStatus Malfunction = new(nameof(Malfunction), 2);
  public static readonly EquipmentStatus Idle = new(nameof(Idle), 3);
  public static readonly EquipmentStatus Stop = new(nameof(Stop), 4);

  protected EquipmentStatus(string name, int value) : base(name, value)
  {
  }
}
