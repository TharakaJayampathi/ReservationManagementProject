using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationManagement.Migrations
{
    public partial class Init35 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Logins");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Logins");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Logins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
