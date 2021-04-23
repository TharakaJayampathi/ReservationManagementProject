using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationManagement.Migrations
{
    public partial class Init36 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Usermanagements_UsermanagementId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Logins",
                newName: "Email");

            migrationBuilder.AlterColumn<int>(
                name: "UsermanagementId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Usermanagements_UsermanagementId",
                table: "Customers",
                column: "UsermanagementId",
                principalTable: "Usermanagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Usermanagements_UsermanagementId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Logins",
                newName: "UserName");

            migrationBuilder.AlterColumn<int>(
                name: "UsermanagementId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Usermanagements_UsermanagementId",
                table: "Customers",
                column: "UsermanagementId",
                principalTable: "Usermanagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
