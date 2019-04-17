using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherBackend.Migrations
{
    public partial class BirdWatcherDBv10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "devTempLight",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "PhotoresistorValue",
                table: "devTempLight",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "BirdLog",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Temperature",
                table: "devTempLight",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "PhotoresistorValue",
                table: "devTempLight",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<int>(
                name: "Temperature",
                table: "BirdLog",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
