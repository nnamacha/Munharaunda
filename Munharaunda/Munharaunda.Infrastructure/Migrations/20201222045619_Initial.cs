using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Munharaunda.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funeral",
                columns: table => new
                {
                    FuneralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeceasedsProfileNumber = table.Column<int>(type: "int", nullable: false),
                    AddressForFuneral = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funeral", x => x.FuneralId);
                });

            migrationBuilder.CreateTable(
                name: "IdentityTypes",
                columns: table => new
                {
                    IdentityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityTypes", x => x.IdentityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileTypes",
                columns: table => new
                {
                    ProfileTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTypes", x => x.ProfileTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approve1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver1 = table.Column<int>(type: "int", nullable: false),
                    Approve2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver2 = table.Column<int>(type: "int", nullable: false),
                    Approve3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver3 = table.Column<int>(type: "int", nullable: false),
                    Approve4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver4 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "StatusesHistory",
                columns: table => new
                {
                    StatusHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    StatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approve1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver1 = table.Column<int>(type: "int", nullable: false),
                    Approve2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver2 = table.Column<int>(type: "int", nullable: false),
                    Approve3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver3 = table.Column<int>(type: "int", nullable: false),
                    Approve4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver4 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusesHistory", x => x.StatusHistoryId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCodes",
                columns: table => new
                {
                    TransactionCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<bool>(type: "bit", nullable: false),
                    Contribution = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCodes", x => x.TransactionCodeId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionCodesHistory",
                columns: table => new
                {
                    TransactionCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<bool>(type: "bit", nullable: false),
                    Contribution = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCodesHistory", x => x.TransactionCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuneralId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionCode = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Approve1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver1 = table.Column<int>(type: "int", nullable: false),
                    Approve2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver2 = table.Column<int>(type: "int", nullable: false),
                    Approve3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver3 = table.Column<int>(type: "int", nullable: false),
                    Approve4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver4 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsArchive",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuneralId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionCode = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Approve1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver1 = table.Column<int>(type: "int", nullable: false),
                    Approve2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver2 = table.Column<int>(type: "int", nullable: false),
                    Approve3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver3 = table.Column<int>(type: "int", nullable: false),
                    Approve4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver4 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsArchive", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityTypeId = table.Column<int>(type: "int", nullable: false),
                    NextOfKin = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ReOpen = table.Column<bool>(type: "bit", nullable: false),
                    ReOpenedBy = table.Column<int>(type: "int", nullable: false),
                    ReOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approve1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver1 = table.Column<int>(type: "int", nullable: false),
                    Approve2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver2 = table.Column<int>(type: "int", nullable: false),
                    Approve3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver3 = table.Column<int>(type: "int", nullable: false),
                    Approve4 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approver4 = table.Column<int>(type: "int", nullable: false),
                    IdentityTypesIdentityTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileNumber);
                    table.ForeignKey(
                        name: "FK_Profile_IdentityTypes_IdentityTypesIdentityTypeId",
                        column: x => x.IdentityTypesIdentityTypeId,
                        principalTable: "IdentityTypes",
                        principalColumn: "IdentityTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IdentityTypesIdentityTypeId",
                table: "Profile",
                column: "IdentityTypesIdentityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funeral");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "ProfileTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "StatusesHistory");

            migrationBuilder.DropTable(
                name: "TransactionCodes");

            migrationBuilder.DropTable(
                name: "TransactionCodesHistory");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionsArchive");

            migrationBuilder.DropTable(
                name: "IdentityTypes");
        }
    }
}
