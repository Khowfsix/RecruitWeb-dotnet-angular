using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class modify_LocationAndTime_Interview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ITRS",
                table: "Interview");

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
                name: "ITRSInterviewId",
                table: "Interview",
                newName: "ItrsinterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_ITRSInterviewId",
                table: "Interview",
                newName: "IX_Interview_ItrsinterviewId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(1749),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(5285),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(7769));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Interview",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailLocation",
                table: "Interview",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Interview",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingDate",
                table: "Interview",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Interview",
                type: "time",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(354),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(2788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 962, DateTimeKind.Local).AddTicks(6388),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 565, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(6586),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(9279));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_ITRSInterview_ItrsinterviewId",
                table: "Interview",
                column: "ItrsinterviewId",
                principalTable: "ITRSInterview",
                principalColumn: "ITRSInterviewId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interview_ITRSInterview_ItrsinterviewId",
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
                name: "Address",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "DetailLocation",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "MeetingDate",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Interview");

            migrationBuilder.RenameColumn(
                name: "ItrsinterviewId",
                table: "Interview",
                newName: "ITRSInterviewId");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_ItrsinterviewId",
                table: "Interview",
                newName: "IX_Interview_ITRSInterviewId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(4301),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(1749));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(7769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(5285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(2788),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 565, DateTimeKind.Local).AddTicks(1490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 962, DateTimeKind.Local).AddTicks(6388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 10, 23, 17, 16, 571, DateTimeKind.Local).AddTicks(9279),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 15, 20, 51, 43, 968, DateTimeKind.Local).AddTicks(6586));

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

            migrationBuilder.AddForeignKey(
                name: "FK_ITRS",
                table: "Interview",
                column: "ITRSInterviewId",
                principalTable: "ITRSInterview",
                principalColumn: "ITRSInterviewId");
        }
    }
}
