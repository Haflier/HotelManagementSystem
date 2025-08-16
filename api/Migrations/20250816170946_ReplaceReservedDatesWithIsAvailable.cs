using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceReservedDatesWithIsAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Room");

            migrationBuilder.AddColumn<string>(
                name: "ReservedDates",
                table: "Room",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservedDates",
                table: "Room");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Room",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
