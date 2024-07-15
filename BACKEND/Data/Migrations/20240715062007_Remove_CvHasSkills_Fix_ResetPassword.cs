using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Remove_CvHasSkills_Fix_ResetPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResetPasswords",
                table: "ResetPasswords");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ResetPasswords",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK__ResetPassword__DF539B9C8196430E",
                table: "ResetPasswords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ResetPasswords_UserId",
                table: "ResetPasswords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResetPasswordUser",
                table: "ResetPasswords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResetPasswordUser",
                table: "ResetPasswords");

            migrationBuilder.DropPrimaryKey(
                name: "PK__ResetPassword__DF539B9C8196430E",
                table: "ResetPasswords");

            migrationBuilder.DropIndex(
                name: "IX_ResetPasswords_UserId",
                table: "ResetPasswords");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ResetPasswords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResetPasswords",
                table: "ResetPasswords",
                column: "Id");
        }
    }
}
