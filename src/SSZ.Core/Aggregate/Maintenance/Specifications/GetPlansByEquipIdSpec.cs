namespace SSZ.Core.Aggregate.Maintenance.Specifications;

public sealed class GetPlansByEquipIdSpec:Specification<MaintenancePlan>
{
  public GetPlansByEquipIdSpec(Guid equipmentId)
  {
    Query.Where(x => x.EquipmentId == equipmentId);
  }
}
