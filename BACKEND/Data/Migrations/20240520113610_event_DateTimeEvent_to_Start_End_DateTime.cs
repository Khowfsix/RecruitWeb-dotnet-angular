using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class event_DateTimeEvent_to_Start_End_DateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(2640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(5657),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(1247),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 19, DateTimeKind.Local).AddTicks(3198),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 768, DateTimeKind.Local).AddTicks(8550));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(7095),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(3308));

            migrationBuilder.CreateTable(
                name: "EventHasPositions",
                columns: table => new
                {
                    EventHasPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventHasPosition__7944C8101630D001", x => x.EventHasPositionId);
                    table.ForeignKey(
                        name: "FK_EventHasPositions",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId");
                    table.ForeignKey(
                        name: "FK_PositionJoinEvents",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId");
                });

          
            migrationBuilder.CreateIndex(
                name: "IX_EventHasPositions_EventId",
                table: "EventHasPositions",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventHasPositions_PositionId",
                table: "EventHasPositions",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventHasPositions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(5331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(2640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "PersonalProject",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(1700),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(5657));

            migrationBuilder.AlterColumn<DateTime>(
                name: "From",
                table: "Education",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 777, DateTimeKind.Local).AddTicks(3409),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(1247));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Certificate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 768, DateTimeKind.Local).AddTicks(8550),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 19, DateTimeKind.Local).AddTicks(3198));

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Award",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 7, 22, 28, 32, 780, DateTimeKind.Local).AddTicks(3308),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 20, 18, 36, 10, 24, DateTimeKind.Local).AddTicks(7095));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "32ad5ba2-4ecf-4873-9df4-d73d8260b39e", "4", "Admin", "Admin" },
                    { "48a4cf91-5de7-46bb-b4e4-f19383c32d29", "1", "Candidate", "Candidate" },
                    { "4c0cdb4c-7788-4d6b-8107-4a47df88fdba", "3", "Recruiter", "Recruiter" },
                    { "6af6c4c0-519f-4118-86b2-1acbcb401800", "2", "Interviewer", "Interviewer" }
                });
        }
    }
}
