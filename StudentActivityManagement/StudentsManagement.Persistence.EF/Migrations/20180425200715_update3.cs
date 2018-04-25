using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsManagement.Persistence.EF.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityStudents",
                table: "ActivityStudents");

            migrationBuilder.DropIndex(
                name: "IX_ActivityStudents_ActivityId",
                table: "ActivityStudents");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StudentActivityInfo");

            migrationBuilder.AddColumn<int>(
                name: "OccuranceId",
                table: "StudentActivityInfo",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityStudents",
                table: "ActivityStudents",
                columns: new[] { "ActivityId", "StudentId" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivityInfo_OccuranceId",
                table: "StudentActivityInfo",
                column: "OccuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentActivityInfo_ScheduleEntry_OccuranceId",
                table: "StudentActivityInfo",
                column: "OccuranceId",
                principalTable: "ScheduleEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentActivityInfo_ScheduleEntry_OccuranceId",
                table: "StudentActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_StudentActivityInfo_OccuranceId",
                table: "StudentActivityInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActivityStudents",
                table: "ActivityStudents");

            migrationBuilder.DropColumn(
                name: "OccuranceId",
                table: "StudentActivityInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StudentActivityInfo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActivityStudents",
                table: "ActivityStudents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStudents_ActivityId",
                table: "ActivityStudents",
                column: "ActivityId");
        }
    }
}
