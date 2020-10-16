using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Migrations
{
    public partial class addIncidentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Engineers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncidentTitle = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IncidentDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_IncidentId",
                table: "Machines",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_Engineers_IncidentId",
                table: "Engineers",
                column: "IncidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_Incidents_IncidentId",
                table: "Engineers",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "IncidentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Incidents_IncidentId",
                table: "Machines",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "IncidentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_Incidents_IncidentId",
                table: "Engineers");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Incidents_IncidentId",
                table: "Machines");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Machines_IncidentId",
                table: "Machines");

            migrationBuilder.DropIndex(
                name: "IX_Engineers_IncidentId",
                table: "Engineers");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "IncidentId",
                table: "Engineers");
        }
    }
}
