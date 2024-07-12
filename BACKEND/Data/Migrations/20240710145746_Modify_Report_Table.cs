using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Report_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReccerCreateReport",
                table: "Report");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecruiterId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Report",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FileURL",
                table: "Report",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReportType",
                table: "Report",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Report",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserId",
                table: "Report",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Recruiter_RecruiterId",
                table: "Report",
                column: "RecruiterId",
                principalTable: "Recruiter",
                principalColumn: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "Fk_ReportOfUser",
                table: "Report",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Recruiter_RecruiterId",
                table: "Report");

            migrationBuilder.DropForeignKey(
                name: "Fk_ReportOfUser",
                table: "Report");

            migrationBuilder.DropIndex(
                name: "IX_Report_UserId",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "FileURL",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "ReportType",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Report");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecruiterId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReccerCreateReport",
                table: "Report",
                column: "RecruiterId",
                principalTable: "Recruiter",
                principalColumn: "RecruiterId");
        }
    }
}
