using SSZ.Core.Aggregate.ProductionLine;

namespace SSZ.Infrastructure.Data.Config;

public class ProductionLineConfiguration: IEntityTypeConfiguration<ProductionLine>
{
  public void Configure(EntityTypeBuilder<ProductionLine> builder)
  {
    builder.Property(p => p.Name)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.Property(p => p.Code)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.Property(p => p.ParentCode)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();
    builder.OwnsMany(a => a.Equipments)
      .WithOwner().HasForeignKey("ProductionLineId");
    // builder.OwnsMany(a=>a.Equipments, b =>
    // {
    //   b.WithOwner().HasForeignKey("ProductionLineId");
    //
    //   b.Property(e => e.Value)
    //     .HasColumnName("EquipmentId")
    //     .IsRequired();
    //
    //   b.HasKey("ProductionLineId", "EquipmentId");
    //
    //   b.ToTable("ProductionLine_EquipmentIds");
    //   b.Navigation("_equipmentIds").UsePropertyAccessMode(PropertyAccessMode.Field);
    // });


    builder.Property(x => x.Level)
      .HasConversion(
        x => x.Value,
        x => LineLevel.FromValue(x));
  }
}
