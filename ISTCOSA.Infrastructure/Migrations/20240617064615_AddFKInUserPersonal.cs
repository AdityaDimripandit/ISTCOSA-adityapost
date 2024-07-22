using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFKInUserPersonal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStudentId",
                table: "UserPersonalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserWorkId",
                table: "UserPersonalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalInformation_UserStudentId",
                table: "UserPersonalInformation",
                column: "UserStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalInformation_UserWorkId",
                table: "UserPersonalInformation",
                column: "UserWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalInformation_userStudents_UserStudentId",
                table: "UserPersonalInformation",
                column: "UserStudentId",
                principalTable: "userStudents",
                principalColumn: "Id");

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
                name: "FK_UserPersonalInformation_userStudents_UserStudentId",
                table: "UserPersonalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalInformation_userWorks_UserWorkId",
                table: "UserPersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserPersonalInformation_UserStudentId",
                table: "UserPersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserPersonalInformation_UserWorkId",
                table: "UserPersonalInformation");

            migrationBuilder.DropColumn(
                name: "UserStudentId",
                table: "UserPersonalInformation");

            migrationBuilder.DropColumn(
                name: "UserWorkId",
                table: "UserPersonalInformation");
        }
    }
}
