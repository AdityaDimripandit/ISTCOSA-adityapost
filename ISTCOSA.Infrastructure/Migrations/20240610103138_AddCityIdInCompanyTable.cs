using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCityIdInCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_UserPersonalInformation_UserPersonalInformationId",
                table: "companies");

            migrationBuilder.DropIndex(
                name: "IX_companies_UserPersonalInformationId",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "UserPersonalInformationId",
                table: "companies");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_companies_CityId",
                table: "companies",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_cities_CityId",
                table: "companies",
                column: "CityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_companies_cities_CityId",
                table: "companies");

            migrationBuilder.DropIndex(
                name: "IX_companies_CityId",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "companies");

            migrationBuilder.AddColumn<int>(
                name: "UserPersonalInformationId",
                table: "companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_companies_UserPersonalInformationId",
                table: "companies",
                column: "UserPersonalInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_companies_UserPersonalInformation_UserPersonalInformationId",
                table: "companies",
                column: "UserPersonalInformationId",
                principalTable: "UserPersonalInformation",
                principalColumn: "Id");
        }
    }
}
