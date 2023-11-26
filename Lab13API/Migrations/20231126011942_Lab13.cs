using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab13API.Migrations
{
    public partial class Lab13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "active",
                table: "Products",
                newName: "Active");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Products",
                newName: "active");
        }
    }
}
