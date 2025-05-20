namespace SSZ.Core.Aggregate.EquipmentType;

public class EquipmentType:EntityBase<Guid>,IAggregateRoot
{
  public string Name { get;private set; } = string.Empty;
  public string Code { get;private set; } = string.Empty;
  public bool Enabled { get;private set; } = false;

  public EquipmentType(string name, string code)
  {
    Name = Guard.Against.NullOrWhiteSpace(name);
    Code = Guard.Against.NullOrWhiteSpace(code);
  }
  private EquipmentType(){}

  public void ChangeStatus(bool enabled)
  {
    Enabled=Guard.Against.Null(enabled);
  }
}
