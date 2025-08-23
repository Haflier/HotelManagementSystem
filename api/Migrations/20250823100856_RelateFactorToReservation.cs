using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RelateFactorToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Factor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Factor_ReservationId",
                table: "Factor",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factor_Reservation_ReservationId",
                table: "Factor",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factor_Reservation_ReservationId",
                table: "Factor");

            migrationBuilder.DropIndex(
                name: "IX_Factor_ReservationId",
                table: "Factor");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Factor");
        }
    }
}
