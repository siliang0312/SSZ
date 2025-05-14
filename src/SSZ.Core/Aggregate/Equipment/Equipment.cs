namespace SSZ.Core.Aggregate.Equipment;

public class Equipment(string name,string code):EntityBase<Guid>,IAggregateRoot
{
  public string Name { get; private set; } = Guard.Against.NullOrWhiteSpace(name,nameof(name));
  public string Code { get; private set; } = Guard.Against.NullOrWhiteSpace(code,nameof(code));
  public Guid ProductionLineGuid { get; private set; } = Guid.Empty;
  public EquipmentStatus Status { get; private set; } = EquipmentStatus.Normal;

  public void UpdateProductionLine(Guid productionLineGuid) => ProductionLineGuid = productionLineGuid;
  public void UpdateEquipmentStatus(EquipmentStatus status) => Status = status;
}
