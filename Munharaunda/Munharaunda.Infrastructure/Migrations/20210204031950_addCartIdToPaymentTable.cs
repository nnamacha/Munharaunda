using Microsoft.EntityFrameworkCore.Migrations;

namespace Munharaunda.Infrastructure.Migrations
{
    public partial class addCartIdToPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Payments");
        }
    }
}
