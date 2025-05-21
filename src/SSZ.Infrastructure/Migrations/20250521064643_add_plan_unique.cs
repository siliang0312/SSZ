using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSZ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_plan_unique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_EquipmentId_MaintenanceItemId",
                table: "MaintenancePlans",
                columns: new[] { "EquipmentId", "MaintenanceItemId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MaintenancePlans_EquipmentId_MaintenanceItemId",
                table: "MaintenancePlans");
        }
    }
}
