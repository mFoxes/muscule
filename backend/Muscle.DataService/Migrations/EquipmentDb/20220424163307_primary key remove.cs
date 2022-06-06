using Microsoft.EntityFrameworkCore.Migrations;

namespace Muscle.DataService.Migrations.EquipmentDb
{
    public partial class primarykeyremove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "EquipmentHalls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EquipmentHalls",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
