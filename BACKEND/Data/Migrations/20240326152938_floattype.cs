using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class floattype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "244dfc81-5c33-443a-b009-d62a255940a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8be07cc6-efa1-4ecb-8a35-c28aaa44ed13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9044432c-7417-4dd9-9bc8-d4c8258d7fd7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4786767-adf2-4b41-90a6-55b9ade6ca58");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d7be195-7da8-48c4-858c-981167c970b1", "2", "Interviewer", "Interviewer" },
                    { "3cb8e3c3-346d-4b44-8941-de6b9f2372c1", "4", "Admin", "Admin" },
                    { "86244b61-08fb-4f1a-a1a4-6dd4182f14ea", "3", "Recruiter", "Recruiter" },
                    { "f4d4f4de-85f2-4dc7-8ec7-893c42806506", "1", "Candidate", "Candidate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d7be195-7da8-48c4-858c-981167c970b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb8e3c3-346d-4b44-8941-de6b9f2372c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86244b61-08fb-4f1a-a1a4-6dd4182f14ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4d4f4de-85f2-4dc7-8ec7-893c42806506");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "244dfc81-5c33-443a-b009-d62a255940a6", "3", "Recruiter", "Recruiter" },
                    { "8be07cc6-efa1-4ecb-8a35-c28aaa44ed13", "1", "Candidate", "Candidate" },
                    { "9044432c-7417-4dd9-9bc8-d4c8258d7fd7", "4", "Admin", "Admin" },
                    { "d4786767-adf2-4b41-90a6-55b9ade6ca58", "2", "Interviewer", "Interviewer" }
                });
        }
    }
}
