using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeFKRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userWorks_UserPersonalInformation_UserPersonalInformationId",
                table: "userWorks");

            migrationBuilder.DropIndex(
                name: "IX_userWorks_UserPersonalInformationId",
                table: "userWorks");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_userWorks_UserPersonalInformationId",
                table: "userWorks",
                column: "UserPersonalInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_userWorks_UserPersonalInformation_UserPersonalInformationId",
                table: "userWorks",
                column: "UserPersonalInformationId",
                principalTable: "UserPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
