namespace SSZ.Core.Aggregate.Maintenance.Specifications;

public sealed class GetPlanByIdsSpec:Specification<MaintenancePlan>
{
  public GetPlanByIdsSpec(List<Guid> planIds)
  {
    Query
      .Where(a =>planIds.Contains(a.Id) );
  }
}
