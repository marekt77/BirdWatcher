using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherBackend.Migrations
{
    public partial class NewSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirdLog_Birds_BirdId",
                table: "BirdLog");

            migrationBuilder.DropIndex(
                name: "IX_BirdLog_BirdId",
                table: "BirdLog");

            migrationBuilder.DropColumn(
                name: "BirdId",
                table: "BirdLog");

            migrationBuilder.RenameColumn(
                name: "ImageFile",
                table: "Birds",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "BirdType",
                table: "Birds",
                newName: "ExamplePicture");

            migrationBuilder.AddColumn<long>(
                name: "BirdLogId",
                table: "Birds",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "BirdLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Birds_BirdLogId",
                table: "Birds",
                column: "BirdLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_BirdLog_BirdLogId",
                table: "Birds",
                column: "BirdLogId",
                principalTable: "BirdLog",
                principalColumn: "BirdLogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birds_BirdLog_BirdLogId",
                table: "Birds");

            migrationBuilder.DropIndex(
                name: "IX_Birds_BirdLogId",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "BirdLogId",
                table: "Birds");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "BirdLog");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Birds",
                newName: "ImageFile");

            migrationBuilder.RenameColumn(
                name: "ExamplePicture",
                table: "Birds",
                newName: "BirdType");

            migrationBuilder.AddColumn<long>(
                name: "BirdId",
                table: "BirdLog",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BirdLog_BirdId",
                table: "BirdLog",
                column: "BirdId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirdLog_Birds_BirdId",
                table: "BirdLog",
                column: "BirdId",
                principalTable: "Birds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
