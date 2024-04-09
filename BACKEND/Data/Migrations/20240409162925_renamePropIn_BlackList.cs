using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class renamePropIn_BlackList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "010f3321-c20d-4080-bc8a-e26370b7acd1", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "010f3321-c20d-4080-bc8a-e26370b7acd1", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9ddf7f2b-50d9-4b08-be52-3a01afbf612f", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c98b24cb-3acf-494b-bd49-2829fd573d4a", "ff01cfbf-c330-4332-b500-07f33f10e8ce" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "010f3321-c20d-4080-bc8a-e26370b7acd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ffa778f-ec76-4b4a-8525-5d5549cf7937");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ddf7f2b-50d9-4b08-be52-3a01afbf612f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c98b24cb-3acf-494b-bd49-2829fd573d4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc43d9d-84bf-47f5-a1d4-7c990f903723");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff01cfbf-c330-4332-b500-07f33f10e8ce");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "BlackList",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(3794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(1227),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(6572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.AlterColumn<string>(
                name: "AboutMe",
                table: "CV",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 242, DateTimeKind.Local).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 531, DateTimeKind.Local).AddTicks(6735));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(3825),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(8021));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CreatedAt",
                table: "BlackList",
                newName: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(3260),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(3794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(6572),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(1227));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(1824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 248, DateTimeKind.Local).AddTicks(186));

            migrationBuilder.AlterColumn<string>(
                name: "AboutMe",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 531, DateTimeKind.Local).AddTicks(6735),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 242, DateTimeKind.Local).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 9, 18, 20, 40, 537, DateTimeKind.Local).AddTicks(8021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 9, 23, 29, 25, 249, DateTimeKind.Local).AddTicks(3825));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "010f3321-c20d-4080-bc8a-e26370b7acd1", "1", "Candidate", "Candidate" },
                    { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "3", "Recruiter", "Recruiter" },
                    { "9ddf7f2b-50d9-4b08-be52-3a01afbf612f", "4", "Admin", "Admin" },
                    { "c98b24cb-3acf-494b-bd49-2829fd573d4a", "2", "Interviewer", "Interviewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dbc43d9d-84bf-47f5-a1d4-7c990f903723", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" },
                    { "ff01cfbf-c330-4332-b500-07f33f10e8ce", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "010f3321-c20d-4080-bc8a-e26370b7acd1", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" },
                    { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "dbc43d9d-84bf-47f5-a1d4-7c990f903723" },
                    { "010f3321-c20d-4080-bc8a-e26370b7acd1", "ff01cfbf-c330-4332-b500-07f33f10e8ce" },
                    { "2ffa778f-ec76-4b4a-8525-5d5549cf7937", "ff01cfbf-c330-4332-b500-07f33f10e8ce" },
                    { "9ddf7f2b-50d9-4b08-be52-3a01afbf612f", "ff01cfbf-c330-4332-b500-07f33f10e8ce" },
                    { "c98b24cb-3acf-494b-bd49-2829fd573d4a", "ff01cfbf-c330-4332-b500-07f33f10e8ce" }
                });
        }
    }
}
