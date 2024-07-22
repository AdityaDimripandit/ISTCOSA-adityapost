using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addstudentidinpersonal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userStudentId",
                table: "UserPersonalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalInformation_userStudentId",
                table: "UserPersonalInformation",
                column: "userStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalInformation_userStudents_userStudentId",
                table: "UserPersonalInformation",
                column: "userStudentId",
                principalTable: "userStudents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalInformation_userStudents_userStudentId",
                table: "UserPersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserPersonalInformation_userStudentId",
                table: "UserPersonalInformation");

            migrationBuilder.DropColumn(
                name: "userStudentId",
                table: "UserPersonalInformation");
        }
    }
}
