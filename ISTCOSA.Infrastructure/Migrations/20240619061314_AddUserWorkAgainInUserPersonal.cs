using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserWorkAgainInUserPersonal : Migration
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

            migrationBuilder.DropColumn(
                name: "UserPersonalInformationId",
                table: "userWorks");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalInformation_UserWorkId",
                table: "UserPersonalInformation",
                column: "UserWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalInformation_userWorks_UserWorkId",
                table: "UserPersonalInformation",
                column: "UserWorkId",
                principalTable: "userWorks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalInformation_userWorks_UserWorkId",
                table: "UserPersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserPersonalInformation_UserWorkId",
                table: "UserPersonalInformation");

            migrationBuilder.AddColumn<int>(
                name: "UserPersonalInformationId",
                table: "userWorks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userWorks_UserPersonalInformationId",
                table: "userWorks",
                column: "UserPersonalInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_userWorks_UserPersonalInformation_UserPersonalInformationId",
                table: "userWorks",
                column: "UserPersonalInformationId",
                principalTable: "UserPersonalInformation",
                principalColumn: "Id");
        }
    }
}
