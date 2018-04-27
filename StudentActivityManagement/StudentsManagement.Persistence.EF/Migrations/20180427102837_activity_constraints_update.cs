using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsManagement.Persistence.EF.Migrations
{
    public partial class activity_constraints_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_Activities_ActivityId",
                table: "ScheduleEntry");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "ScheduleEntry",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_Activities_ActivityId",
                table: "ScheduleEntry",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleEntry_Activities_ActivityId",
                table: "ScheduleEntry");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "ScheduleEntry",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleEntry_Activities_ActivityId",
                table: "ScheduleEntry",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
