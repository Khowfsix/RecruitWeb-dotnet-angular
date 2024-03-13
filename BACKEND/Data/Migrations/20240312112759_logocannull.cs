using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class logocannull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0721cdb5-5027-457b-ac68-2d1ed8273c58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f49a9cf-c12c-4cb8-9c08-082cfb7c5f74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac469261-7a78-439c-84a8-f0f915d2bcc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aec3221d-17a9-4b8a-8a66-c652faa6eca3");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Company",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a71fbd4-10cf-4d64-b583-1456431dfa93", "3", "Recruiter", "Recruiter" },
                    { "d0527dc4-891a-412e-8ac0-60c6414f5f49", "2", "Interviewer", "Interviewer" },
                    { "d2d03cf9-a680-42ed-ae13-da6890ef1e06", "4", "Admin", "Admin" },
                    { "f5d8ddfa-5b05-4066-a3c0-5ed495b508f2", "1", "Candidate", "Candidate" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a71fbd4-10cf-4d64-b583-1456431dfa93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0527dc4-891a-412e-8ac0-60c6414f5f49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2d03cf9-a680-42ed-ae13-da6890ef1e06");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5d8ddfa-5b05-4066-a3c0-5ed495b508f2");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0721cdb5-5027-457b-ac68-2d1ed8273c58", "2", "Interviewer", "Interviewer" },
                    { "9f49a9cf-c12c-4cb8-9c08-082cfb7c5f74", "3", "Recruiter", "Recruiter" },
                    { "ac469261-7a78-439c-84a8-f0f915d2bcc7", "4", "Admin", "Admin" },
                    { "aec3221d-17a9-4b8a-8a66-c652faa6eca3", "1", "Candidate", "Candidate" }
                });
        }
    }
}
