using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class statusInterger : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a4194aa-a266-4c98-a071-497b181f27f2", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5e773e4e-e6ba-4a5a-a850-a1b87c2d393a", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "72ab207f-15d8-4093-8a49-6f741a4b174e", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7f18016c-1676-44fb-b89c-f5fffc9d77e8", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a4194aa-a266-4c98-a071-497b181f27f2", "41bd8250-796a-4375-b21a-222f0101872f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5e773e4e-e6ba-4a5a-a850-a1b87c2d393a", "41bd8250-796a-4375-b21a-222f0101872f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a4194aa-a266-4c98-a071-497b181f27f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e773e4e-e6ba-4a5a-a850-a1b87c2d393a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72ab207f-15d8-4093-8a49-6f741a4b174e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f18016c-1676-44fb-b89c-f5fffc9d77e8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00c96ac3-e16f-4859-bfa2-49eb24dc838c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41bd8250-796a-4375-b21a-222f0101872f");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(2157),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(5708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(739));

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "Interview",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Company_Status",
                table: "Interview",
                type: "int",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Candidate_Status",
                table: "Interview",
                type: "int",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 182, DateTimeKind.Local).AddTicks(1780),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 539, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(7528),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.AlterColumn<int>(
                name: "Priority",
                table: "Application",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Company_Status",
                table: "Application",
                type: "int",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Candidate_Status",
                table: "Application",
                type: "int",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad0eaac5-479e-4647-bd92-19c7239e8a72", "2", "Interviewer", "Interviewer" },
                    { "b55437e9-a7fa-4383-8080-dfbb590af8e1", "4", "Admin", "Admin" },
                    { "d2b9a373-e2c1-4ae4-b794-a34311f2db2a", "1", "Candidate", "Candidate" },
                    { "fcce651a-02ac-4039-ae80-37b30b1f4114", "3", "Recruiter", "Recruiter" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "19b2ea9b-5aec-453e-b72d-75250ad7b4b7", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" },
                    { "c59d7b36-86c7-4361-abf8-893845d231cf", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "d2b9a373-e2c1-4ae4-b794-a34311f2db2a", "19b2ea9b-5aec-453e-b72d-75250ad7b4b7" },
                    { "fcce651a-02ac-4039-ae80-37b30b1f4114", "19b2ea9b-5aec-453e-b72d-75250ad7b4b7" },
                    { "ad0eaac5-479e-4647-bd92-19c7239e8a72", "c59d7b36-86c7-4361-abf8-893845d231cf" },
                    { "b55437e9-a7fa-4383-8080-dfbb590af8e1", "c59d7b36-86c7-4361-abf8-893845d231cf" },
                    { "d2b9a373-e2c1-4ae4-b794-a34311f2db2a", "c59d7b36-86c7-4361-abf8-893845d231cf" },
                    { "fcce651a-02ac-4039-ae80-37b30b1f4114", "c59d7b36-86c7-4361-abf8-893845d231cf" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2b9a373-e2c1-4ae4-b794-a34311f2db2a", "19b2ea9b-5aec-453e-b72d-75250ad7b4b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fcce651a-02ac-4039-ae80-37b30b1f4114", "19b2ea9b-5aec-453e-b72d-75250ad7b4b7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad0eaac5-479e-4647-bd92-19c7239e8a72", "c59d7b36-86c7-4361-abf8-893845d231cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b55437e9-a7fa-4383-8080-dfbb590af8e1", "c59d7b36-86c7-4361-abf8-893845d231cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2b9a373-e2c1-4ae4-b794-a34311f2db2a", "c59d7b36-86c7-4361-abf8-893845d231cf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fcce651a-02ac-4039-ae80-37b30b1f4114", "c59d7b36-86c7-4361-abf8-893845d231cf" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad0eaac5-479e-4647-bd92-19c7239e8a72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b55437e9-a7fa-4383-8080-dfbb590af8e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2b9a373-e2c1-4ae4-b794-a34311f2db2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fcce651a-02ac-4039-ae80-37b30b1f4114");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19b2ea9b-5aec-453e-b72d-75250ad7b4b7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c59d7b36-86c7-4361-abf8-893845d231cf");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(7146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(2157));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(5708));

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Interview",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company_Status",
                table: "Interview",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Candidate_Status",
                table: "Interview",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(5681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 539, DateTimeKind.Local).AddTicks(7773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 182, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(2172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 47, 52, 187, DateTimeKind.Local).AddTicks(7528));

            migrationBuilder.AlterColumn<string>(
                name: "Priority",
                table: "Application",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company_Status",
                table: "Application",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Candidate_Status",
                table: "Application",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a4194aa-a266-4c98-a071-497b181f27f2", "3", "Recruiter", "Recruiter" },
                    { "5e773e4e-e6ba-4a5a-a850-a1b87c2d393a", "1", "Candidate", "Candidate" },
                    { "72ab207f-15d8-4093-8a49-6f741a4b174e", "4", "Admin", "Admin" },
                    { "7f18016c-1676-44fb-b89c-f5fffc9d77e8", "2", "Interviewer", "Interviewer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00c96ac3-e16f-4859-bfa2-49eb24dc838c", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" },
                    { "41bd8250-796a-4375-b21a-222f0101872f", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1a4194aa-a266-4c98-a071-497b181f27f2", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" },
                    { "5e773e4e-e6ba-4a5a-a850-a1b87c2d393a", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" },
                    { "72ab207f-15d8-4093-8a49-6f741a4b174e", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" },
                    { "7f18016c-1676-44fb-b89c-f5fffc9d77e8", "00c96ac3-e16f-4859-bfa2-49eb24dc838c" },
                    { "1a4194aa-a266-4c98-a071-497b181f27f2", "41bd8250-796a-4375-b21a-222f0101872f" },
                    { "5e773e4e-e6ba-4a5a-a850-a1b87c2d393a", "41bd8250-796a-4375-b21a-222f0101872f" }
                });
        }
    }
}
