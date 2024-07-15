using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_CvHasSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CV_has_Skills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CV_has_Skills",
                columns: table => new
                {
                    CV_SkillsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cvid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExperienceYear = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CV_has_S__21EE6FE772D382E5", x => x.CV_SkillsId);
                    table.ForeignKey(
                        name: "FK_CV_has_Skills_CV_Cvid",
                        column: x => x.Cvid,
                        principalTable: "CV",
                        principalColumn: "Cvid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hasSkill",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CV_has_Skills_Cvid",
                table: "CV_has_Skills",
                column: "Cvid");

            migrationBuilder.CreateIndex(
                name: "IX_CV_has_Skills_SkillId",
                table: "CV_has_Skills",
                column: "SkillId");
        }
    }
}
