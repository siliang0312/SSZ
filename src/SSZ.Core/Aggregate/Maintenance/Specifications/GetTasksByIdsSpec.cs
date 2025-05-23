namespace SSZ.Core.Aggregate.Maintenance.Specifications;

public sealed class GetTasksByIdsSpec:Specification<MaintenanceTask>
{
  public GetTasksByIdsSpec(List<Guid> ids)
  {
    Query
      .Where(a => ids.Contains(a.Id));
  }
}
