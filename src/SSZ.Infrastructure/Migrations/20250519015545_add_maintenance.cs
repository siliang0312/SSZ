using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSZ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_maintenance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    EquipmentTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaintenanceCycle_CycleType = table.Column<int>(type: "INTEGER", nullable: true),
                    MaintenanceCycle_IntervalTime = table.Column<int>(type: "INTEGER", nullable: true),
                    MaintenanceCycle_DayOfPeriod = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaintenanceItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastDateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NextDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaintenanceItemName = table.Column<string>(type: "TEXT", nullable: false),
                    MaintenanceItemContent = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<string>(type: "TEXT", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    EquipmentName = table.Column<string>(type: "TEXT", nullable: false),
                    EquipmentTypeName = table.Column<string>(type: "TEXT", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompleteTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Feedback = table.Column<string>(type: "TEXT", nullable: true),
                    AuditOpinion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipmentId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaintenanceItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    MaintenancePlanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CompleteTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Feedback = table.Column<string>(type: "TEXT", nullable: true),
                    AuditOpinion = table.Column<string>(type: "TEXT", nullable: true),
                    ImageId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTasks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceItems");

            migrationBuilder.DropTable(
                name: "MaintenancePlans");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "MaintenanceTasks");
        }
    }
}
