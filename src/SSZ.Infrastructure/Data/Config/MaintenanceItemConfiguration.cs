using SSZ.Core.Aggregate.Maintenance;

namespace SSZ.Infrastructure.Data.Config;

public class MaintenanceItemConfiguration: IEntityTypeConfiguration<MaintenanceItem>
{
  public void Configure(EntityTypeBuilder<MaintenanceItem> builder)
  {
    
    builder.OwnsOne(builder=> builder.MaintenanceCycle, mc =>
    {
      mc.Property(x=>x.CycleType).HasConversion(
        x => x.Value,
        x => MaintenanceCycleType.FromValue(x));
    });
    
  }
}
