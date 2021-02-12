using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherWeb.Migrations
{
    public partial class HealthCheckUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "SunTrack",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WatcherHealthCheck",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hostname = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    IP = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CPU_Temp = table.Column<float>(type: "float", nullable: false),
                    GPU_Temp = table.Column<float>(type: "float", nullable: false),
                    Disk_Total = table.Column<long>(type: "bigint", nullable: false),
                    Disk_Used = table.Column<long>(type: "bigint", nullable: false),
                    Disk_Free = table.Column<long>(type: "bigint", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WatcherHealthCheck", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WatcherHealthCheck");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "SunTrack");
        }
    }
}
