using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherBackend.Migrations
{
    public partial class many2many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birds_BirdLog_BirdLogID",
                table: "Birds");

            migrationBuilder.DropIndex(
                name: "IX_Birds_BirdLogID",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "BirdLogID",
                table: "Birds");

            migrationBuilder.AddColumn<float>(
                name: "Location_latitude",
                table: "BirdLog",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "UserGUID",
                table: "BirdLog",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "location_longitude",
                table: "BirdLog",
                nullable: false,
                defaultValue: 0f);

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

            migrationBuilder.DropColumn(
                name: "Location_latitude",
                table: "BirdLog");

            migrationBuilder.DropColumn(
                name: "UserGUID",
                table: "BirdLog");

            migrationBuilder.DropColumn(
                name: "location_longitude",
                table: "BirdLog");

            migrationBuilder.AddColumn<long>(
                name: "BirdLogID",
                table: "Birds",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Birds_BirdLogID",
                table: "Birds",
                column: "BirdLogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_BirdLog_BirdLogID",
                table: "Birds",
                column: "BirdLogID",
                principalTable: "BirdLog",
                principalColumn: "BirdLogID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
