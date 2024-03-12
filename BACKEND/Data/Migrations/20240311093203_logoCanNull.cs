using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class logoCanNull : Migration
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
                    { "08583de4-e08f-4030-a746-b8331a833557", "3", "Recruiter", "Recruiter" },
                    { "2a91956f-f674-40f9-95db-3a313c7ef8de", "4", "Admin", "Admin" },
                    { "4c9d291c-dce4-4204-a084-18da72e5f077", "1", "Candidate", "Candidate" },
                    { "bca7e303-59a7-4589-9060-e6fb25fb1b5d", "2", "Interviewer", "Interviewer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08583de4-e08f-4030-a746-b8331a833557");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a91956f-f674-40f9-95db-3a313c7ef8de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c9d291c-dce4-4204-a084-18da72e5f077");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bca7e303-59a7-4589-9060-e6fb25fb1b5d");

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
