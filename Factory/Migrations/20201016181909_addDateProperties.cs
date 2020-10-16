using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Migrations
{
    public partial class addDateProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InspectionDate",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseRenewal",
                table: "Engineers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InspectionDate",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "LicenseRenewal",
                table: "Engineers");
        }
    }
}
