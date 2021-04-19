using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationManagement.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Bookings_BookingId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Reservationplans");

            migrationBuilder.DropColumn(
                name: "RoomTypeAmount",
                table: "Reservationplans");

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "Reservationplans");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Users",
                newName: "UsermanagementId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_BookingId",
                table: "Users",
                newName: "IX_Users_UsermanagementId");

            migrationBuilder.RenameColumn(
                name: "RoomType",
                table: "Reservationplans",
                newName: "ReservationplanType");

            migrationBuilder.CreateTable(
                name: "Usermanagements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usermanagements", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Usermanagements_UsermanagementId",
                table: "Users",
                column: "UsermanagementId",
                principalTable: "Usermanagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Usermanagements_UsermanagementId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Usermanagements");

            migrationBuilder.RenameColumn(
                name: "UsermanagementId",
                table: "Users",
                newName: "BookingId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UsermanagementId",
                table: "Users",
                newName: "IX_Users_BookingId");

            migrationBuilder.RenameColumn(
                name: "ReservationplanType",
                table: "Reservationplans",
                newName: "RoomType");

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Reservationplans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "RoomTypeAmount",
                table: "Reservationplans",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Rooms",
                table: "Reservationplans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Bookings_BookingId",
                table: "Users",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
