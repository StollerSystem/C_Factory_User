using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Migrations
{
    public partial class addStatusProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MachineStatus",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EngineerStatus",
                table: "Engineers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineStatus",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "EngineerStatus",
                table: "Engineers");
        }
    }
}
