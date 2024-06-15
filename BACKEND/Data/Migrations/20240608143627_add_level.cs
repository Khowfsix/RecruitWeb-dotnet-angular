using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class add_level : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_level", x => x.LevelId);
                });

            //migrationBuilder.InsertData(
            //    table: "Level",
            //    columns: new[] { "LevelId", "IsDeleted", "LevelName" },
            //    values: new object[,]
            //    {
            //        { new Guid("00000000-0000-0000-0000-000000000000"), false, "Null Level" },
            //    });

            migrationBuilder.AddColumn<Guid>(
                name: "LevelId",
                table: "Position",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Position_LevelId",
                table: "Position",
                column: "LevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LevelPosition",
                table: "Position",
                column: "LevelId",
                principalTable: "Level",
                principalColumn: "LevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LevelPosition",
                table: "Position");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropIndex(
                name: "IX_Position_LevelId",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "LevelId",
                table: "Position");
        }
    }
}
