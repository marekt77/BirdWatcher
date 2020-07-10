using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherBackend.Migrations
{
    public partial class InitialMySQLSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirdLog",
                columns: table => new
                {
                    BirdLogID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Temperature = table.Column<float>(nullable: false),
                    Location_latitude = table.Column<float>(nullable: false),
                    location_longitude = table.Column<float>(nullable: false),
                    UserGUID = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdLog", x => x.BirdLogID);
                });

            migrationBuilder.CreateTable(
                name: "Birds",
                columns: table => new
                {
                    BirdID = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    ExamplePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birds", x => x.BirdID);
                });

            migrationBuilder.CreateTable(
                name: "devTempLight",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Temperature = table.Column<float>(nullable: false),
                    PhotoresistorValue = table.Column<float>(nullable: false),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devTempLight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BirdLogBird",
                columns: table => new
                {
                    BirdID = table.Column<long>(nullable: false),
                    BirdLogID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdLogBird", x => new { x.BirdID, x.BirdLogID });
                    table.ForeignKey(
                        name: "FK_BirdLogBird_Birds_BirdID",
                        column: x => x.BirdID,
                        principalTable: "Birds",
                        principalColumn: "BirdID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BirdLogBird_BirdLog_BirdLogID",
                        column: x => x.BirdLogID,
                        principalTable: "BirdLog",
                        principalColumn: "BirdLogID",
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
                name: "devTempLight");

            migrationBuilder.DropTable(
                name: "Birds");

            migrationBuilder.DropTable(
                name: "BirdLog");
        }
    }
}
