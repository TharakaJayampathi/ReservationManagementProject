using Microsoft.EntityFrameworkCore.Migrations;

namespace ReservationManagement.Migrations
{
    public partial class Init37 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Usermanagements_UsermanagementId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "UsermanagementId",
                table: "Customers",
                newName: "PaymentId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_UsermanagementId",
                table: "Customers",
                newName: "IX_Customers_PaymentId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Payments_PaymentId",
                table: "Customers",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Payments_PaymentId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Customers",
                newName: "UsermanagementId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_PaymentId",
                table: "Customers",
                newName: "IX_Customers_UsermanagementId");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Usermanagements_UsermanagementId",
                table: "Customers",
                column: "UsermanagementId",
                principalTable: "Usermanagements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
