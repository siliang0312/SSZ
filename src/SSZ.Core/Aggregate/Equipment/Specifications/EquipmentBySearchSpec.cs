namespace SSZ.Core.Aggregate.Equipment.Specifications;
public class EquipmentBySearchSpec : Specification<Equipment>
{
  public EquipmentBySearchSpec(string? name,string? code) =>
    Query
      .Where(a=>string.IsNullOrWhiteSpace(name)||a.Name.Contains(name))
      .Where(a=>string.IsNullOrWhiteSpace(code)||a.Code.Contains(code))
      
    ;
}
