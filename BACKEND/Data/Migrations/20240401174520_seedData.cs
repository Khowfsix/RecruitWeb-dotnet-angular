using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "347c32b8-33ee-4c24-a0fe-28b79e62e0d2", "4", "Admin", "Admin" },
                    { "5343a1d1-78f5-4f96-a275-05b614feccae", "1", "Candidate", "Candidate" },
                    { "71dd8ab2-893e-4105-a9af-b6ab164340db", "3", "Recruiter", "Recruiter" },
                    { "d5577554-ab97-4eee-bcb3-eb99cb8d2476", "2", "Interviewer", "Interviewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "987ed908-234a-4343-8e50-fcc44d6fd9ea", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" },
                    { "bf328094-07c0-4f89-aad4-258c79acd243", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "347c32b8-33ee-4c24-a0fe-28b79e62e0d2", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "5343a1d1-78f5-4f96-a275-05b614feccae", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "71dd8ab2-893e-4105-a9af-b6ab164340db", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "d5577554-ab97-4eee-bcb3-eb99cb8d2476", "987ed908-234a-4343-8e50-fcc44d6fd9ea" },
                    { "5343a1d1-78f5-4f96-a275-05b614feccae", "bf328094-07c0-4f89-aad4-258c79acd243" },
                    { "71dd8ab2-893e-4105-a9af-b6ab164340db", "bf328094-07c0-4f89-aad4-258c79acd243" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "347c32b8-33ee-4c24-a0fe-28b79e62e0d2", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5343a1d1-78f5-4f96-a275-05b614feccae", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71dd8ab2-893e-4105-a9af-b6ab164340db", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d5577554-ab97-4eee-bcb3-eb99cb8d2476", "987ed908-234a-4343-8e50-fcc44d6fd9ea" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5343a1d1-78f5-4f96-a275-05b614feccae", "bf328094-07c0-4f89-aad4-258c79acd243" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71dd8ab2-893e-4105-a9af-b6ab164340db", "bf328094-07c0-4f89-aad4-258c79acd243" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "347c32b8-33ee-4c24-a0fe-28b79e62e0d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5343a1d1-78f5-4f96-a275-05b614feccae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71dd8ab2-893e-4105-a9af-b6ab164340db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5577554-ab97-4eee-bcb3-eb99cb8d2476");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "987ed908-234a-4343-8e50-fcc44d6fd9ea");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf328094-07c0-4f89-aad4-258c79acd243");

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
    }
}
