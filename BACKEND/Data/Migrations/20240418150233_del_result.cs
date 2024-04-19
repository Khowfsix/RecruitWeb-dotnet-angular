using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class del_result : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultInterview",
                table: "Interview");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Interview_ResultId",
                table: "Interview");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6f677d80-15bf-4eac-8791-e6a5881e38f4", "566ef3de-b982-40cb-8dd1-efa340192267" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "837a110a-ba2f-45da-9bb0-8c28ca8bf363", "566ef3de-b982-40cb-8dd1-efa340192267" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c28f0a39-3a8f-4fae-bee4-51a45308bc6f", "566ef3de-b982-40cb-8dd1-efa340192267" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8bedc37-8b2b-4cd9-9ec9-f8b5676848a6", "566ef3de-b982-40cb-8dd1-efa340192267" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6f677d80-15bf-4eac-8791-e6a5881e38f4", "f175d39d-cf40-4aa4-890e-4b8df0c73f0e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d8bedc37-8b2b-4cd9-9ec9-f8b5676848a6", "f175d39d-cf40-4aa4-890e-4b8df0c73f0e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6f677d80-15bf-4eac-8791-e6a5881e38f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837a110a-ba2f-45da-9bb0-8c28ca8bf363");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c28f0a39-3a8f-4fae-bee4-51a45308bc6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8bedc37-8b2b-4cd9-9ec9-f8b5676848a6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "566ef3de-b982-40cb-8dd1-efa340192267");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f175d39d-cf40-4aa4-890e-4b8df0c73f0e");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Interview");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(7146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.AddColumn<string>(
                name: "AnswerString",
                table: "SecurityAnswer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(5681),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 88, DateTimeKind.Local).AddTicks(9794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 539, DateTimeKind.Local).AddTicks(7773),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 83, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(2172),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(6377));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "AnswerString",
                table: "SecurityAnswer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(1362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(4815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(739));

            migrationBuilder.AddColumn<Guid>(
                name: "ResultId",
                table: "Interview",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 88, DateTimeKind.Local).AddTicks(9794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 544, DateTimeKind.Local).AddTicks(5681));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 83, DateTimeKind.Local).AddTicks(9733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 539, DateTimeKind.Local).AddTicks(7773));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(6377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 18, 22, 2, 33, 545, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ResultString = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Result__976902081579C0D7", x => x.ResultId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6f677d80-15bf-4eac-8791-e6a5881e38f4", "3", "Recruiter", "Recruiter" },
                    { "837a110a-ba2f-45da-9bb0-8c28ca8bf363", "4", "Admin", "Admin" },
                    { "c28f0a39-3a8f-4fae-bee4-51a45308bc6f", "2", "Interviewer", "Interviewer" },
                    { "d8bedc37-8b2b-4cd9-9ec9-f8b5676848a6", "1", "Candidate", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "566ef3de-b982-40cb-8dd1-efa340192267", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" },
                    { "f175d39d-cf40-4aa4-890e-4b8df0c73f0e", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6f677d80-15bf-4eac-8791-e6a5881e38f4", "566ef3de-b982-40cb-8dd1-efa340192267" },
                    { "837a110a-ba2f-45da-9bb0-8c28ca8bf363", "566ef3de-b982-40cb-8dd1-efa340192267" },
                    { "c28f0a39-3a8f-4fae-bee4-51a45308bc6f", "566ef3de-b982-40cb-8dd1-efa340192267" },
                    { "d8bedc37-8b2b-4cd9-9ec9-f8b5676848a6", "566ef3de-b982-40cb-8dd1-efa340192267" },
                    { "6f677d80-15bf-4eac-8791-e6a5881e38f4", "f175d39d-cf40-4aa4-890e-4b8df0c73f0e" },
                    { "d8bedc37-8b2b-4cd9-9ec9-f8b5676848a6", "f175d39d-cf40-4aa4-890e-4b8df0c73f0e" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interview_ResultId",
                table: "Interview",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultInterview",
                table: "Interview",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "ResultId");
        }
    }
}
