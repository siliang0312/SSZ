namespace SSZ.Core.Aggregate.ProductionLine;

public class EquipmentId(Guid value):ValueObject
{
  public Guid Value { get; private set; }=value;
  protected override IEnumerable<object> GetEqualityComponents()
  {
    yield return Value;
  }
}
