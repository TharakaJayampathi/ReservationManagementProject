using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationManagement.Migrations
{
    public partial class Init17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Reservationplans_ReservationplanId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_ReservationplanId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ReservationplanId",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationplanId",
                table: "Rooms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BookingId",
                table: "Rooms",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ReservationplanId",
                table: "Rooms",
                column: "ReservationplanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Bookings_BookingId",
                table: "Rooms",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Reservationplans_ReservationplanId",
                table: "Rooms",
                column: "ReservationplanId",
                principalTable: "Reservationplans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
