using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class renamePropIn_Application : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c0becb-694d-40a1-9f30-68a69e6a07a4", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a27fafe-fd30-415f-99bb-ffcad6e91050", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c702f67a-f866-4856-b6c2-71b5ad0e3dbd", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6c0841c-151b-4a83-8815-42b9384ad1b6", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65c0becb-694d-40a1-9f30-68a69e6a07a4", "41d399a3-20ab-4d13-b556-c3d00a8cfa1d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9a27fafe-fd30-415f-99bb-ffcad6e91050", "41d399a3-20ab-4d13-b556-c3d00a8cfa1d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65c0becb-694d-40a1-9f30-68a69e6a07a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a27fafe-fd30-415f-99bb-ffcad6e91050");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c702f67a-f866-4856-b6c2-71b5ad0e3dbd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6c0841c-151b-4a83-8815-42b9384ad1b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0aeb42a3-c886-406d-a0aa-f5bb42f65841");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41d399a3-20ab-4d13-b556-c3d00a8cfa1d");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Application",
                newName: "CreatedTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(4301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(3794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(7769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(2788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 565, DateTimeKind.Local).AddTicks(1490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 242, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(9279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06d6d68a-5fbb-4eb3-a615-25d96a936a64", "2", "Interviewer", "Interviewer" },
                    { "41a75301-08ed-45ff-962e-1ead14267faf", "1", "Candidate", "Candidate" },
                    { "94a81e0b-50d6-43ed-be82-8c4bd7f8bf86", "4", "Admin", "Admin" },
                    { "b1d529f8-0199-48f5-bc1f-a0f8b580dbbb", "3", "Recruiter", "Recruiter" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dd9f234d-f9ca-41a7-b19a-f0811b3a8f2c", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" },
                    { "f6e047ce-95c1-4201-bf34-8b35e2de83c2", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "41a75301-08ed-45ff-962e-1ead14267faf", "dd9f234d-f9ca-41a7-b19a-f0811b3a8f2c" },
                    { "b1d529f8-0199-48f5-bc1f-a0f8b580dbbb", "dd9f234d-f9ca-41a7-b19a-f0811b3a8f2c" },
                    { "06d6d68a-5fbb-4eb3-a615-25d96a936a64", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" },
                    { "41a75301-08ed-45ff-962e-1ead14267faf", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" },
                    { "94a81e0b-50d6-43ed-be82-8c4bd7f8bf86", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" },
                    { "b1d529f8-0199-48f5-bc1f-a0f8b580dbbb", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41a75301-08ed-45ff-962e-1ead14267faf", "dd9f234d-f9ca-41a7-b19a-f0811b3a8f2c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1d529f8-0199-48f5-bc1f-a0f8b580dbbb", "dd9f234d-f9ca-41a7-b19a-f0811b3a8f2c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "06d6d68a-5fbb-4eb3-a615-25d96a936a64", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "41a75301-08ed-45ff-962e-1ead14267faf", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94a81e0b-50d6-43ed-be82-8c4bd7f8bf86", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1d529f8-0199-48f5-bc1f-a0f8b580dbbb", "f6e047ce-95c1-4201-bf34-8b35e2de83c2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06d6d68a-5fbb-4eb3-a615-25d96a936a64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41a75301-08ed-45ff-962e-1ead14267faf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a81e0b-50d6-43ed-be82-8c4bd7f8bf86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1d529f8-0199-48f5-bc1f-a0f8b580dbbb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd9f234d-f9ca-41a7-b19a-f0811b3a8f2c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6e047ce-95c1-4201-bf34-8b35e2de83c2");

            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Application",
                newName: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(3794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(1227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 242, DateTimeKind.Local).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 565, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(3825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "65c0becb-694d-40a1-9f30-68a69e6a07a4", "3", "Recruiter", "Recruiter" },
                    { "9a27fafe-fd30-415f-99bb-ffcad6e91050", "1", "Candidate", "Candidate" },
                    { "c702f67a-f866-4856-b6c2-71b5ad0e3dbd", "4", "Admin", "Admin" },
                    { "e6c0841c-151b-4a83-8815-42b9384ad1b6", "2", "Interviewer", "Interviewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0aeb42a3-c886-406d-a0aa-f5bb42f65841", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" },
                    { "41d399a3-20ab-4d13-b556-c3d00a8cfa1d", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "65c0becb-694d-40a1-9f30-68a69e6a07a4", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" },
                    { "9a27fafe-fd30-415f-99bb-ffcad6e91050", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" },
                    { "c702f67a-f866-4856-b6c2-71b5ad0e3dbd", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" },
                    { "e6c0841c-151b-4a83-8815-42b9384ad1b6", "0aeb42a3-c886-406d-a0aa-f5bb42f65841" },
                    { "65c0becb-694d-40a1-9f30-68a69e6a07a4", "41d399a3-20ab-4d13-b556-c3d00a8cfa1d" },
                    { "9a27fafe-fd30-415f-99bb-ffcad6e91050", "41d399a3-20ab-4d13-b556-c3d00a8cfa1d" }
                });
        }
    }
}
