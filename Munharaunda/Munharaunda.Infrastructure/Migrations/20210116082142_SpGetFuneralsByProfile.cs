using Microsoft.EntityFrameworkCore.Migrations;

namespace Munharaunda.Infrastructure.Migrations
{
	public partial class SpGetFuneralsByProfile : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			var sp = @"CREATE PROCEDURE GetFuneralsByProfile(
					 @ProfileID int,
					@PaidFunerals bit)
								AS
								BEGIN
					IF @PaidFunerals = 1
					BEGIN
						SELECT* FROM Funeral WHERE FuneralId in (select FuneralId from Transactions where CreatedBy = @ProfileID)
					END
					ELSE
						SELECT* FROM Funeral WHERE Created > (select Created from Profile where ProfileNumber = @ProfileID) and FuneralId NOT IN(select FuneralId from Transactions where CreatedBy = @ProfileID)
				END
				GO";
			migrationBuilder.Sql(sp);

		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}