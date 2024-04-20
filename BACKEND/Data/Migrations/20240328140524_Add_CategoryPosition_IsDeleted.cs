using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_CategoryPosition_IsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CategoryPosition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "15299902-41e8-491f-a0af-4eeddf5222c2", "2", "Interviewer", "Interviewer" },
                    { "594bd4f8-8319-4db5-b04c-e8e79f2bcbda", "3", "Recruiter", "Recruiter" },
                    { "947a1791-781d-47ac-9b05-5d955b91b515", "1", "Candidate", "Candidate" },
                    { "97d8b4a5-6b01-4f36-baae-2188a9c98268", "4", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CategoryPosition");

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
