using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class connectAzure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "193bc3b6-3437-4f4a-bf65-96035b89fad9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58e37aec-3e4d-4826-8db9-46fa37c26c33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3626f9f-a4da-4b58-836e-390c3a5a9d88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5ef1029-43c2-4330-8192-2d993ce06593");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "51371e00-370f-4d2a-851d-66577c889f85", "2", "Interviewer", "Interviewer" },
                    { "6cbddd9e-6288-4e9f-82c9-300d14b8f6d9", "3", "Recruiter", "Recruiter" },
                    { "6f169ed7-7ad4-4700-af12-185af8c2dd82", "1", "Candidate", "Candidate" },
                    { "d8a92a79-69df-4e57-b269-7bd04082d9a3", "4", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51371e00-370f-4d2a-851d-66577c889f85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cbddd9e-6288-4e9f-82c9-300d14b8f6d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f169ed7-7ad4-4700-af12-185af8c2dd82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8a92a79-69df-4e57-b269-7bd04082d9a3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "193bc3b6-3437-4f4a-bf65-96035b89fad9", "3", "Recruiter", "Recruiter" },
                    { "58e37aec-3e4d-4826-8db9-46fa37c26c33", "4", "Admin", "Admin" },
                    { "a3626f9f-a4da-4b58-836e-390c3a5a9d88", "1", "Candidate", "Candidate" },
                    { "f5ef1029-43c2-4330-8192-2d993ce06593", "2", "Interviewer", "Interviewer" }
                });
        }
    }
}
