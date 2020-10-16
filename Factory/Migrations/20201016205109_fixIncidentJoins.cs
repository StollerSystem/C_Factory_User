using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Migrations
{
    public partial class fixIncidentJoins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentJoin_Engineers_EngineerId",
                table: "IncidentJoin");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentJoin_Incidents_IncidentId",
                table: "IncidentJoin");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentJoin_Machines_MachineId",
                table: "IncidentJoin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentJoin",
                table: "IncidentJoin");

            migrationBuilder.RenameTable(
                name: "IncidentJoin",
                newName: "IncidentJoins");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentJoin_MachineId",
                table: "IncidentJoins",
                newName: "IX_IncidentJoins_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentJoin_IncidentId",
                table: "IncidentJoins",
                newName: "IX_IncidentJoins_IncidentId");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentJoin_EngineerId",
                table: "IncidentJoins",
                newName: "IX_IncidentJoins_EngineerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentJoins",
                table: "IncidentJoins",
                column: "IncidentJoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentJoins_Engineers_EngineerId",
                table: "IncidentJoins",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentJoins_Incidents_IncidentId",
                table: "IncidentJoins",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "IncidentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentJoins_Machines_MachineId",
                table: "IncidentJoins",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncidentJoins_Engineers_EngineerId",
                table: "IncidentJoins");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentJoins_Incidents_IncidentId",
                table: "IncidentJoins");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentJoins_Machines_MachineId",
                table: "IncidentJoins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IncidentJoins",
                table: "IncidentJoins");

            migrationBuilder.RenameTable(
                name: "IncidentJoins",
                newName: "IncidentJoin");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentJoins_MachineId",
                table: "IncidentJoin",
                newName: "IX_IncidentJoin_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentJoins_IncidentId",
                table: "IncidentJoin",
                newName: "IX_IncidentJoin_IncidentId");

            migrationBuilder.RenameIndex(
                name: "IX_IncidentJoins_EngineerId",
                table: "IncidentJoin",
                newName: "IX_IncidentJoin_EngineerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IncidentJoin",
                table: "IncidentJoin",
                column: "IncidentJoinId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentJoin_Engineers_EngineerId",
                table: "IncidentJoin",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentJoin_Incidents_IncidentId",
                table: "IncidentJoin",
                column: "IncidentId",
                principalTable: "Incidents",
                principalColumn: "IncidentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentJoin_Machines_MachineId",
                table: "IncidentJoin",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
