using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICustomer.Migrations
{
    public partial class AjoutEnumCustomerCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "customerCategory",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "customerCategory",
                table: "Customers");
        }
    }
}
