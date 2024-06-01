using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addPersonalDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "32ad5ba2-4ecf-4873-9df4-d73d8260b39e", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "48a4cf91-5de7-46bb-b4e4-f19383c32d29", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "4c0cdb4c-7788-4d6b-8107-4a47df88fdba", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "6af6c4c0-519f-4118-86b2-1acbcb401800", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "48a4cf91-5de7-46bb-b4e4-f19383c32d29", "9c729756-d973-4b14-86cf-a912019f2189" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "4c0cdb4c-7788-4d6b-8107-4a47df88fdba", "9c729756-d973-4b14-86cf-a912019f2189" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "32ad5ba2-4ecf-4873-9df4-d73d8260b39e");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "48a4cf91-5de7-46bb-b4e4-f19383c32d29");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "4c0cdb4c-7788-4d6b-8107-4a47df88fdba");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "6af6c4c0-519f-4118-86b2-1acbcb401800");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "9c729756-d973-4b14-86cf-a912019f2189");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 271, DateTimeKind.Local).AddTicks(9142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 272, DateTimeKind.Local).AddTicks(6671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 271, DateTimeKind.Local).AddTicks(5279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 265, DateTimeKind.Local).AddTicks(4942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 768, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 272, DateTimeKind.Local).AddTicks(9161),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonalLink",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "105d3b39-bd4f-4d84-9f49-a359be9ed345", "1", "Candidate", "Candidate" },
            //        { "2fb8f8a8-7d47-4679-8b55-56f5f11df173", "4", "Admin", "Admin" },
            //        { "3002412a-8498-4a97-a0d1-a18ea96a7dcf", "3", "Recruiter", "Recruiter" },
            //        { "9b972521-03bb-4369-bb0e-8743a863009f", "2", "Interviewer", "Interviewer" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "Gender", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalLink", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Title", "TwoFactorEnabled", "UserName" },
            //    values: new object[,]
            //    {
            //        { "68a7e9fc-811d-4184-ac11-c8e77c0829b9", 0, null, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", null, false, "AdminJasmine" },
            //        { "da8d473f-e3f5-4ade-bd6f-8a902ad9900b", 0, null, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", null, false, "lyhongphat" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "105d3b39-bd4f-4d84-9f49-a359be9ed345", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" },
            //        { "2fb8f8a8-7d47-4679-8b55-56f5f11df173", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" },
            //        { "3002412a-8498-4a97-a0d1-a18ea96a7dcf", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" },
            //        { "9b972521-03bb-4369-bb0e-8743a863009f", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" },
            //        { "105d3b39-bd4f-4d84-9f49-a359be9ed345", "da8d473f-e3f5-4ade-bd6f-8a902ad9900b" },
            //        { "3002412a-8498-4a97-a0d1-a18ea96a7dcf", "da8d473f-e3f5-4ade-bd6f-8a902ad9900b" }
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "105d3b39-bd4f-4d84-9f49-a359be9ed345", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "2fb8f8a8-7d47-4679-8b55-56f5f11df173", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "3002412a-8498-4a97-a0d1-a18ea96a7dcf", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "9b972521-03bb-4369-bb0e-8743a863009f", "68a7e9fc-811d-4184-ac11-c8e77c0829b9" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "105d3b39-bd4f-4d84-9f49-a359be9ed345", "da8d473f-e3f5-4ade-bd6f-8a902ad9900b" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "3002412a-8498-4a97-a0d1-a18ea96a7dcf", "da8d473f-e3f5-4ade-bd6f-8a902ad9900b" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "105d3b39-bd4f-4d84-9f49-a359be9ed345");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "2fb8f8a8-7d47-4679-8b55-56f5f11df173");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "3002412a-8498-4a97-a0d1-a18ea96a7dcf");

            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "9b972521-03bb-4369-bb0e-8743a863009f");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "68a7e9fc-811d-4184-ac11-c8e77c0829b9");

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "da8d473f-e3f5-4ade-bd6f-8a902ad9900b");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonalLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(5331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 271, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(1700),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 272, DateTimeKind.Local).AddTicks(6671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(3409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 271, DateTimeKind.Local).AddTicks(5279));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 768, DateTimeKind.Local).AddTicks(8550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 265, DateTimeKind.Local).AddTicks(4942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(3308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 30, 4, 39, 38, 272, DateTimeKind.Local).AddTicks(9161));

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "32ad5ba2-4ecf-4873-9df4-d73d8260b39e", "4", "Admin", "Admin" },
            //        { "48a4cf91-5de7-46bb-b4e4-f19383c32d29", "1", "Candidate", "Candidate" },
            //        { "4c0cdb4c-7788-4d6b-8107-4a47df88fdba", "3", "Recruiter", "Recruiter" },
            //        { "6af6c4c0-519f-4118-86b2-1acbcb401800", "2", "Interviewer", "Interviewer" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[,]
            //    {
            //        { "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" },
            //        { "9c729756-d973-4b14-86cf-a912019f2189", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[,]
            //    {
            //        { "32ad5ba2-4ecf-4873-9df4-d73d8260b39e", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" },
            //        { "48a4cf91-5de7-46bb-b4e4-f19383c32d29", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" },
            //        { "4c0cdb4c-7788-4d6b-8107-4a47df88fdba", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" },
            //        { "6af6c4c0-519f-4118-86b2-1acbcb401800", "4c73cd72-e4cf-4b2d-a6da-6d1b0950cdd4" },
            //        { "48a4cf91-5de7-46bb-b4e4-f19383c32d29", "9c729756-d973-4b14-86cf-a912019f2189" },
            //        { "4c0cdb4c-7788-4d6b-8107-4a47df88fdba", "9c729756-d973-4b14-86cf-a912019f2189" }
            //    });
        }
    }
}
