using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Infrastructure.Data.Config;

public class MaintenanceTaskConfiguration:  IEntityTypeConfiguration<MaintenanceTask>
{
  public void Configure(EntityTypeBuilder<MaintenanceTask> builder)
  {
    builder.Property(a=>a.State)
      .HasConversion(x => x.Value,
    x => TaskState.FromValue(x));
  }
}
