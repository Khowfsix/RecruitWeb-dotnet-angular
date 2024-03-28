using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class floattype2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Position",
                type: "decimal(12,10)",
                precision: 12,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0deeffdf-fb40-4546-8091-ea2e31cac582", "1", "Candidate", "Candidate" },
                    { "8162fe8f-ec26-4565-b399-9234b02812c8", "3", "Recruiter", "Recruiter" },
                    { "8aa2116c-d713-43a9-b143-9bab8df1b376", "4", "Admin", "Admin" },
                    { "a4292b54-79b8-4f21-bae3-babfab861ddb", "2", "Interviewer", "Interviewer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0deeffdf-fb40-4546-8091-ea2e31cac582");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8162fe8f-ec26-4565-b399-9234b02812c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8aa2116c-d713-43a9-b143-9bab8df1b376");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4292b54-79b8-4f21-bae3-babfab861ddb");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Position",
                type: "decimal(18,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)",
                oldPrecision: 12,
                oldScale: 10,
                oldNullable: true);

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
    }
}
