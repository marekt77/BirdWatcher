using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherBackend.Migrations
{
    public partial class AddBirdLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Birds");

            migrationBuilder.CreateTable(
                name: "BirdLog",
                columns: table => new
                {
                    BirdLogId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Tempurature = table.Column<int>(nullable: false),
                    PhotoresistorValue = table.Column<int>(nullable: false),
                    BirdId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirdLog", x => x.BirdLogId);
                    table.ForeignKey(
                        name: "FK_BirdLog_Birds_BirdId",
                        column: x => x.BirdId,
                        principalTable: "Birds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirdLog_BirdId",
                table: "BirdLog",
                column: "BirdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirdLog");

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                table: "Birds",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
