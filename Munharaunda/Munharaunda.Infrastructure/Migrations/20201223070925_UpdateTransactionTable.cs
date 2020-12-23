using Microsoft.EntityFrameworkCore.Migrations;

namespace Munharaunda.Infrastructure.Migrations
{
    public partial class UpdateTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Contribution",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProfileNumber",
                table: "Funeral",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funeral_ProfileNumber",
                table: "Funeral",
                column: "ProfileNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Funeral_Profile_ProfileNumber",
                table: "Funeral",
                column: "ProfileNumber",
                principalTable: "Profile",
                principalColumn: "ProfileNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funeral_Profile_ProfileNumber",
                table: "Funeral");

            migrationBuilder.DropIndex(
                name: "IX_Funeral_ProfileNumber",
                table: "Funeral");

            migrationBuilder.DropColumn(
                name: "Contribution",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ProfileNumber",
                table: "Funeral");
        }
    }
}
