using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class del_ITRS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_ITRSInterview_ItrsinterviewId",
                table: "Interview");

            migrationBuilder.DropTable(
                name: "ITRSInterview");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropIndex(
                name: "IX_Interview_ItrsinterviewId",
                table: "Interview");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "21bc5c9a-7e02-4491-b59a-cb8b90118a37", "08a11649-c0b5-4547-a7d3-51ff108223bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71894472-ff7c-471c-988e-4339d8b9578d", "08a11649-c0b5-4547-a7d3-51ff108223bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e05ba0ca-fe79-4c1f-9c4d-d40b3c5c2da5", "08a11649-c0b5-4547-a7d3-51ff108223bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7ab0de1-f149-426c-b55e-868930692d13", "08a11649-c0b5-4547-a7d3-51ff108223bf" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "21bc5c9a-7e02-4491-b59a-cb8b90118a37", "272cbcbe-2c7c-415c-82bd-76609bbe15c7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f7ab0de1-f149-426c-b55e-868930692d13", "272cbcbe-2c7c-415c-82bd-76609bbe15c7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21bc5c9a-7e02-4491-b59a-cb8b90118a37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "71894472-ff7c-471c-988e-4339d8b9578d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e05ba0ca-fe79-4c1f-9c4d-d40b3c5c2da5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7ab0de1-f149-426c-b55e-868930692d13");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "08a11649-c0b5-4547-a7d3-51ff108223bf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "272cbcbe-2c7c-415c-82bd-76609bbe15c7");

            migrationBuilder.DropColumn(
                name: "ItrsinterviewId",
                table: "Interview");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(1362),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(4815),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 88, DateTimeKind.Local).AddTicks(9794),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 83, DateTimeKind.Local).AddTicks(9733),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 962, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(6377),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(6586));

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(1749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(1362));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(5285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(4815));

            migrationBuilder.AddColumn<Guid>(
                name: "ItrsinterviewId",
                table: "Interview",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 88, DateTimeKind.Local).AddTicks(9794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 962, DateTimeKind.Local).AddTicks(6388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 83, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(6586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 57, 53, 89, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    RoomName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Room__3286393943AEBB6D", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftTimeEnd = table.Column<int>(type: "int", nullable: false),
                    ShiftTimeStart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shift__C0A83881EF08EB13", x => x.ShiftId);
                });

            migrationBuilder.CreateTable(
                name: "ITRSInterview",
                columns: table => new
                {
                    ITRSInterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateInterview = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ITRSInte__689D871CEED2E961", x => x.ITRSInterviewId);
                    table.ForeignKey(
                        name: "Fk_ITRS_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                    table.ForeignKey(
                        name: "Fk_ITRS_Shift",
                        column: x => x.ShiftId,
                        principalTable: "Shift",
                        principalColumn: "ShiftId");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21bc5c9a-7e02-4491-b59a-cb8b90118a37", "3", "Recruiter", "Recruiter" },
                    { "71894472-ff7c-471c-988e-4339d8b9578d", "4", "Admin", "Admin" },
                    { "e05ba0ca-fe79-4c1f-9c4d-d40b3c5c2da5", "2", "Interviewer", "Interviewer" },
                    { "f7ab0de1-f149-426c-b55e-868930692d13", "1", "Candidate", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FullName", "ImageURL", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "08a11649-c0b5-4547-a7d3-51ff108223bf", 0, null, "37a3f448-08e1-4d5b-8d9d-97edd7ed2441", null, "jasmineandhongphat@gmail.com", true, "Jasmine", null, true, null, "JASMINEANDHONGPHAT@GMAIL.COM", "ADMINJASMINE", "AQAAAAEAACcQAAAAECIlpgtWCyAhui2Dipuu9aK3ICiIStVY9hgOJwdooCgjRvENgPXaHCtjyM43zqc1Bg==", null, false, "KDB5T3VMZDHW3C2T2O3JFSP2TK4OQYRC", false, "AdminJasmine" },
                    { "272cbcbe-2c7c-415c-82bd-76609bbe15c7", 0, null, "d00d37a8-0c8d-4b37-a8b7-823901b3b98d", null, "lyhongphat261202@gmail.com", true, "ly hong phat", null, true, null, "LYHONGPHAT261202@GMAIL.COM", "LYHONGPHAT", "AQAAAAEAACcQAAAAED/UcvE0mbg31jAMWDqc7wtANLZ9+xQrwe4GvRoEW7VHQ4mGKsXvvhv9J367awYVfA==", null, false, "NQBJBUONTUAPYIE7UZDHYJD2NE7VJZEF", false, "lyhongphat" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "21bc5c9a-7e02-4491-b59a-cb8b90118a37", "08a11649-c0b5-4547-a7d3-51ff108223bf" },
                    { "71894472-ff7c-471c-988e-4339d8b9578d", "08a11649-c0b5-4547-a7d3-51ff108223bf" },
                    { "e05ba0ca-fe79-4c1f-9c4d-d40b3c5c2da5", "08a11649-c0b5-4547-a7d3-51ff108223bf" },
                    { "f7ab0de1-f149-426c-b55e-868930692d13", "08a11649-c0b5-4547-a7d3-51ff108223bf" },
                    { "21bc5c9a-7e02-4491-b59a-cb8b90118a37", "272cbcbe-2c7c-415c-82bd-76609bbe15c7" },
                    { "f7ab0de1-f149-426c-b55e-868930692d13", "272cbcbe-2c7c-415c-82bd-76609bbe15c7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interview_ItrsinterviewId",
                table: "Interview",
                column: "ItrsinterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ITRSInterview_RoomId",
                table: "ITRSInterview",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ITRSInterview_ShiftId",
                table: "ITRSInterview",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "UNIQUE_InterviewTime",
                table: "ITRSInterview",
                columns: new[] { "DateInterview", "ShiftId", "RoomId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Room__6B500B55E5A0FA95",
                table: "Room",
                column: "RoomName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_ITRSInterview_ItrsinterviewId",
                table: "Interview",
                column: "ItrsinterviewId",
                principalTable: "ITRSInterview",
                principalColumn: "ITRSInterviewId");
        }
    }
}
