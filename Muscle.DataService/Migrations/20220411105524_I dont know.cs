using Microsoft.EntityFrameworkCore.Migrations;

namespace Muscle.DataService.Migrations
{
    public partial class Idontknow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Coach",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coach_UserId",
                table: "Coach",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coach_Users_UserId",
                table: "Coach",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coach_Users_UserId",
                table: "Coach");

            migrationBuilder.DropIndex(
                name: "IX_Coach_UserId",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Coach");
        }
    }
}
