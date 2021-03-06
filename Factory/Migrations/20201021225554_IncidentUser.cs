﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class IncidentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Incidents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_UserId",
                table: "Incidents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_AspNetUsers_UserId",
                table: "Incidents",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_AspNetUsers_UserId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_UserId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Incidents");
        }
    }
}
