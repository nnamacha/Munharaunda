using Microsoft.EntityFrameworkCore.Migrations;

namespace Munharaunda.Infrastructure.Migrations
{
    public partial class updateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funeral_Profile_ProfileNumber",
                table: "Funeral");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_IdentityTypes_IdentityTypesIdentityTypeId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_IdentityTypesIdentityTypeId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Funeral_ProfileNumber",
                table: "Funeral");

            migrationBuilder.DropColumn(
                name: "IdentityTypesIdentityTypeId",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "ProfileNumber",
                table: "Funeral");

            migrationBuilder.AlterColumn<string>(
                name: "StatusDescription",
                table: "Statuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StatusDescription",
                table: "Statuses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdentityTypesIdentityTypeId",
                table: "Profile",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileNumber",
                table: "Funeral",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IdentityTypesIdentityTypeId",
                table: "Profile",
                column: "IdentityTypesIdentityTypeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_IdentityTypes_IdentityTypesIdentityTypeId",
                table: "Profile",
                column: "IdentityTypesIdentityTypeId",
                principalTable: "IdentityTypes",
                principalColumn: "IdentityTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
