using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp1.Migrations
{
    public partial class UpdatedPrivateCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "PrivateCustomer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PrivateCustomer_CustomerId",
                table: "PrivateCustomer",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrivateCustomer_Customers_CustomerId",
                table: "PrivateCustomer",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrivateCustomer_Customers_CustomerId",
                table: "PrivateCustomer");

            migrationBuilder.DropIndex(
                name: "IX_PrivateCustomer_CustomerId",
                table: "PrivateCustomer");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "PrivateCustomer");
        }
    }
}
