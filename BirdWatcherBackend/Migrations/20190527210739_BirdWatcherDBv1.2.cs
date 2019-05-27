using Microsoft.EntityFrameworkCore.Migrations;

namespace BirdWatcherBackend.Migrations
{
    public partial class BirdWatcherDBv12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birds_BirdLog_BirdLogId",
                table: "Birds");

            migrationBuilder.RenameColumn(
                name: "BirdLogId",
                table: "Birds",
                newName: "BirdLogID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Birds",
                newName: "BirdID");

            migrationBuilder.RenameIndex(
                name: "IX_Birds_BirdLogId",
                table: "Birds",
                newName: "IX_Birds_BirdLogID");

            migrationBuilder.RenameColumn(
                name: "BirdLogId",
                table: "BirdLog",
                newName: "BirdLogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_BirdLog_BirdLogID",
                table: "Birds",
                column: "BirdLogID",
                principalTable: "BirdLog",
                principalColumn: "BirdLogID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birds_BirdLog_BirdLogID",
                table: "Birds");

            migrationBuilder.RenameColumn(
                name: "BirdLogID",
                table: "Birds",
                newName: "BirdLogId");

            migrationBuilder.RenameColumn(
                name: "BirdID",
                table: "Birds",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Birds_BirdLogID",
                table: "Birds",
                newName: "IX_Birds_BirdLogId");

            migrationBuilder.RenameColumn(
                name: "BirdLogID",
                table: "BirdLog",
                newName: "BirdLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Birds_BirdLog_BirdLogId",
                table: "Birds",
                column: "BirdLogId",
                principalTable: "BirdLog",
                principalColumn: "BirdLogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
