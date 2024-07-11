using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Report_Table_Remove_RecruiterId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_Recruiter_RecruiterId",
                table: "Report");

            migrationBuilder.DropIndex(
                name: "IX_Report_RecruiterId",
                table: "Report");


            migrationBuilder.DropColumn(
                name: "RecruiterId",
                table: "Report");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RecruiterId",
                table: "Report",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_RecruiterId",
                table: "Report",
                column: "RecruiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Report_Recruiter_RecruiterId",
                table: "Report",
                column: "RecruiterId",
                principalTable: "Recruiter",
                principalColumn: "RecruiterId");
        }
    }
}
