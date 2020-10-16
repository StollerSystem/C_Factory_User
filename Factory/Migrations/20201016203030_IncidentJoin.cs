using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Migrations
{
    public partial class IncidentJoin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_Incidents_IncidentId",
                table: "Engineers");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Incidents_IncidentId",
                table: "Machines");

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

            migrationBuilder.CreateTable(
                name: "IncidentJoin",
                columns: table => new
                {
                    IncidentJoinId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IncidentId = table.Column<int>(nullable: false),
                    MachineId = table.Column<int>(nullable: false),
                    EngineerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentJoin", x => x.IncidentJoinId);
                    table.ForeignKey(
                        name: "FK_IncidentJoin_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "EngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentJoin_Incidents_IncidentId",
                        column: x => x.IncidentId,
                        principalTable: "Incidents",
                        principalColumn: "IncidentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentJoin_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidentJoin_EngineerId",
                table: "IncidentJoin",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentJoin_IncidentId",
                table: "IncidentJoin",
                column: "IncidentId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentJoin_MachineId",
                table: "IncidentJoin",
                column: "MachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidentJoin");

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Machines",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IncidentId",
                table: "Engineers",
                nullable: true);

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
    }
}
