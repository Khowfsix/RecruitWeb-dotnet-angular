using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class logoCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42ca546d-38bb-4894-818e-9d01aced2684");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "615b8564-22f8-45d8-b20a-2829efe636c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9256779b-19cf-4c57-8ab3-48b9801436e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae9e1417-d8b8-42a7-b1d2-ecad6169cbce");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5d1008c0-158b-435c-a216-6394681519d0", "2", "Interviewer", "Interviewer" },
                    { "9c740272-34ff-4ce2-9133-f87f71ddaa5f", "4", "Admin", "Admin" },
                    { "f48abb9e-227d-4d4c-957c-6087dab29d00", "1", "Candidate", "Candidate" },
                    { "fe76bbf9-957c-48f4-b52c-08cfcf25de63", "3", "Recruiter", "Recruiter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d1008c0-158b-435c-a216-6394681519d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c740272-34ff-4ce2-9133-f87f71ddaa5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f48abb9e-227d-4d4c-957c-6087dab29d00");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe76bbf9-957c-48f4-b52c-08cfcf25de63");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Company");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "42ca546d-38bb-4894-818e-9d01aced2684", "1", "Candidate", "Candidate" },
                    { "615b8564-22f8-45d8-b20a-2829efe636c7", "2", "Interviewer", "Interviewer" },
                    { "9256779b-19cf-4c57-8ab3-48b9801436e7", "3", "Recruiter", "Recruiter" },
                    { "ae9e1417-d8b8-42a7-b1d2-ecad6169cbce", "4", "Admin", "Admin" }
                });
        }
    }
}
