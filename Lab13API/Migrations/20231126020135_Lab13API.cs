using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab13API.Migrations
{
    public partial class Lab13API : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Details_InvoiceId",
                table: "Details",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProductId",
                table: "Details",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Invoices_InvoiceId",
                table: "Details",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "InvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Products_ProductId",
                table: "Details",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_Invoices_InvoiceId",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Products_ProductId",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Details_InvoiceId",
                table: "Details");

            migrationBuilder.DropIndex(
                name: "IX_Details_ProductId",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Details");
        }
    }
}
