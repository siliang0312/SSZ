namespace SSZ.Core.Aggregate.ProductionLine;

public class ProductionLine(string name,string code,LineLevel level,string parentCode): EntityBase<Guid>, IAggregateRoot
{
  public string Name { get; private set; } = Guard.Against.NullOrWhiteSpace(name, nameof(name));
  public string Code { get; private set; } = Guard.Against.NullOrWhiteSpace(code, nameof(code));
  public string ParentCode{get; private set;}=Guard.Against.NullOrWhiteSpace(parentCode, nameof(parentCode));

  public LineLevel Level { get; private set; } = Guard.Against.Null(level, nameof(level));
  
  private readonly List<EquipmentId> _equipmentIds = [];
  
  public IReadOnlyList<EquipmentId> Equipments => _equipmentIds;
  
  public void AddEquipment(EquipmentId id)
  {
    if (!_equipmentIds.Contains(id))
      _equipmentIds.Add(id);
  }

  public void RemoveEquipment(EquipmentId id)
  {
    _equipmentIds.Remove(id);
  }
}
