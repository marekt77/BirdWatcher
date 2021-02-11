using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherWeb.Migrations
{
    public partial class InitBirdWatcherWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirdLog",
                columns: table => new
                {
                    BirdLogID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Temperature = table.Column<float>(type: "float", nullable: false),
                    Location_latitude = table.Column<float>(type: "float", nullable: false),
                    location_longitude = table.Column<float>(type: "float", nullable: false),
                    UserGUID = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Picture = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdLog", x => x.BirdLogID);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    BirdID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    DisplayName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ExamplePicture = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.BirdID);
                });

            migrationBuilder.CreateTable(
                name: "SunTrack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Temperature = table.Column<float>(type: "float", nullable: false),
                    PhotoresistorValue = table.Column<float>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SunTrack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BirdLogBird",
                columns: table => new
                {
                    BirdID = table.Column<long>(type: "bigint", nullable: false),
                    BirdLogID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdLogBird", x => new { x.BirdID, x.BirdLogID });
                    table.ForeignKey(
                        name: "FK_BirdLogBird_BirdLog_BirdLogID",
                        column: x => x.BirdLogID,
                        principalTable: "BirdLog",
                        principalColumn: "BirdLogID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BirdLogBird_Birds_BirdID",
                        column: x => x.BirdID,
                        principalTable: "Birds",
                        principalColumn: "BirdID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirdLogBird_BirdLogID",
                table: "BirdLogBird",
                column: "BirdLogID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirdLogBird");

            migrationBuilder.DropTable(
                name: "SunTrack");

            migrationBuilder.DropTable(
                name: "BirdLog");

            migrationBuilder.DropTable(
                name: "Birds");
        }
    }
}
