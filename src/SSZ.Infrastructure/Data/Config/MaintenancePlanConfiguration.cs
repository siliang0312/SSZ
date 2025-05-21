using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Infrastructure.Data.Config;

public class MaintenancePlanConfiguration: IEntityTypeConfiguration<MaintenancePlan>
{
  public void Configure(EntityTypeBuilder<MaintenancePlan> builder)
  {
    builder
      .HasIndex(a => new { a.EquipmentId, a.MaintenanceItemId })
      .IsUnique();
  }
}
