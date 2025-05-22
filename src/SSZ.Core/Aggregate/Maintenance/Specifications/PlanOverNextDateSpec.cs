namespace SSZ.Core.Aggregate.Maintenance.Specifications;

public sealed class PlanOverNextDateSpec:Specification<MaintenancePlan>
{
  public PlanOverNextDateSpec()
  {
    Query
      .Where(a => a.NextDateTime <= DateTime.UtcNow);
  }
}
