using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class INTERVIEW_change_column_name_to_serve_online_meeting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailLocation",
                table: "Interview",
                newName: "DetailLocationOrJoinURL");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Interview",
                newName: "AddressOrStartURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailLocationOrJoinURL",
                table: "Interview",
                newName: "DetailLocation");

            migrationBuilder.RenameColumn(
                name: "AddressOrStartURL",
                table: "Interview",
                newName: "Address");
        }
    }
}
