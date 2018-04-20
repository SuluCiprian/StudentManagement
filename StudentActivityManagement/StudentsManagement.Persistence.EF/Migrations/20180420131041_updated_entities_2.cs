using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StudentsManagement.Persistence.EF.Migrations
{
    public partial class updated_entities_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityType_TypeId",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityType",
                table: "ActivityType");

            migrationBuilder.RenameTable(
                name: "ActivityType",
                newName: "ActivityTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityTypes",
                table: "ActivityTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityTypes_TypeId",
                table: "Activities",
                column: "TypeId",
                principalTable: "ActivityTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_ActivityTypes_TypeId",
                table: "Activities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityTypes",
                table: "ActivityTypes");

            migrationBuilder.RenameTable(
                name: "ActivityTypes",
                newName: "ActivityType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityType",
                table: "ActivityType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_ActivityType_TypeId",
                table: "Activities",
                column: "TypeId",
                principalTable: "ActivityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
