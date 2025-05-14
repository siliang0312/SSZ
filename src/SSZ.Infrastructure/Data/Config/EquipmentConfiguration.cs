using SSZ.Core.Aggregate.Equipment;

namespace SSZ.Infrastructure.Data.Config;

public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
{
  public void Configure(EntityTypeBuilder<Equipment> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.Property(p => p.Code)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(x => x.Status)
      .HasConversion(
        x => x.Value,
        x => EquipmentStatus.FromValue(x));
  }
}
