using Microsoft.EntityFrameworkCore.Migrations;

namespace Salon.Migrations
{
    public partial class fixMachineEngineers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineEngineer_Engineers_EngineerId",
                table: "MachineEngineer");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineEngineer_Machines_MachineId",
                table: "MachineEngineer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineEngineer",
                table: "MachineEngineer");

            migrationBuilder.RenameTable(
                name: "MachineEngineer",
                newName: "MachineEngineers");

            migrationBuilder.RenameIndex(
                name: "IX_MachineEngineer_MachineId",
                table: "MachineEngineers",
                newName: "IX_MachineEngineers_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineEngineer_EngineerId",
                table: "MachineEngineers",
                newName: "IX_MachineEngineers_EngineerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineEngineers",
                table: "MachineEngineers",
                column: "MachineEngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineEngineers_Engineers_EngineerId",
                table: "MachineEngineers",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineEngineers_Machines_MachineId",
                table: "MachineEngineers",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineEngineers_Engineers_EngineerId",
                table: "MachineEngineers");

            migrationBuilder.DropForeignKey(
                name: "FK_MachineEngineers_Machines_MachineId",
                table: "MachineEngineers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineEngineers",
                table: "MachineEngineers");

            migrationBuilder.RenameTable(
                name: "MachineEngineers",
                newName: "MachineEngineer");

            migrationBuilder.RenameIndex(
                name: "IX_MachineEngineers_MachineId",
                table: "MachineEngineer",
                newName: "IX_MachineEngineer_MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_MachineEngineers_EngineerId",
                table: "MachineEngineer",
                newName: "IX_MachineEngineer_EngineerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineEngineer",
                table: "MachineEngineer",
                column: "MachineEngineerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineEngineer_Engineers_EngineerId",
                table: "MachineEngineer",
                column: "EngineerId",
                principalTable: "Engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MachineEngineer_Machines_MachineId",
                table: "MachineEngineer",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
