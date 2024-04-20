using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    /// <inheritdoc />
    public partial class refreshtokenNoCreateNullUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "15299902-41e8-491f-a0af-4eeddf5222c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "594bd4f8-8319-4db5-b04c-e8e79f2bcbda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "947a1791-781d-47ac-9b05-5d955b91b515");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97d8b4a5-6b01-4f36-baae-2188a9c98268");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1824a9f7-dcac-402b-a750-b2a8384dd200", "4", "Admin", "Admin" },
                    { "240a2b89-598c-439c-8aeb-fd7e4cd295c3", "1", "Candidate", "Candidate" },
                    { "69125160-fff0-4d7d-9c16-8b2aa862f081", "3", "Recruiter", "Recruiter" },
                    { "e368c374-06ed-49b4-854a-acd7d1a9e4f8", "2", "Interviewer", "Interviewer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1824a9f7-dcac-402b-a750-b2a8384dd200");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "240a2b89-598c-439c-8aeb-fd7e4cd295c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69125160-fff0-4d7d-9c16-8b2aa862f081");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e368c374-06ed-49b4-854a-acd7d1a9e4f8");

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
    }
}