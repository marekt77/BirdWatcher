using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherBackend.Migrations
{
    public partial class AddedDisplayNameBirds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Birds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Birds");
        }
    }
}
