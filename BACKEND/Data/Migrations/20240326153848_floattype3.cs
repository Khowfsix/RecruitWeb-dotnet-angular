using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class floattype3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
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
                    { "0dce331e-89eb-4058-99a6-178e3e007b7f", "3", "Recruiter", "Recruiter" },
                    { "6feb772b-062f-4996-8e26-a00dc720a076", "1", "Candidate", "Candidate" },
                    { "9af5d566-1e95-4a8a-a641-25c93e04151a", "2", "Interviewer", "Interviewer" },
                    { "ddde4b8d-b3e3-462b-8cf9-14d36e988730", "4", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dce331e-89eb-4058-99a6-178e3e007b7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6feb772b-062f-4996-8e26-a00dc720a076");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9af5d566-1e95-4a8a-a641-25c93e04151a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddde4b8d-b3e3-462b-8cf9-14d36e988730");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                table: "Position",
                type: "decimal(12,10)",
                precision: 12,
                scale: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2,
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
    }
}
