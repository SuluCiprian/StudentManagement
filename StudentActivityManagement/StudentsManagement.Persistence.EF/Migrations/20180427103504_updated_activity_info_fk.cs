using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsManagement.Persistence.EF.Migrations
{
    public partial class updated_activity_info_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentActivityInfo_ScheduleEntry_OccuranceId",
                table: "StudentActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_StudentActivityInfo_OccuranceId",
                table: "StudentActivityInfo");

            migrationBuilder.DropColumn(
                name: "OccuranceId",
                table: "StudentActivityInfo");

            migrationBuilder.AddColumn<int>(
                name: "OccurenceId",
                table: "StudentActivityInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StudentActivityInfo_OccurenceId",
                table: "StudentActivityInfo",
                column: "OccurenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentActivityInfo_ScheduleEntry_OccurenceId",
                table: "StudentActivityInfo",
                column: "OccurenceId",
                principalTable: "ScheduleEntry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentActivityInfo_ScheduleEntry_OccurenceId",
                table: "StudentActivityInfo");

            migrationBuilder.DropIndex(
                name: "IX_StudentActivityInfo_OccurenceId",
                table: "StudentActivityInfo");

            migrationBuilder.DropColumn(
                name: "OccurenceId",
                table: "StudentActivityInfo");

            migrationBuilder.AddColumn<int>(
                name: "OccuranceId",
                table: "StudentActivityInfo",
                nullable: true);

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
    }
}
