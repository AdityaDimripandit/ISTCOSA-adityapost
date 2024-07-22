using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletestudentidfromuserpersonal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPersonalInformation_userStudents_UserStudentId",
                table: "UserPersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_UserPersonalInformation_UserStudentId",
                table: "UserPersonalInformation");

            migrationBuilder.DropColumn(
                name: "UserStudentId",
                table: "UserPersonalInformation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStudentId",
                table: "UserPersonalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalInformation_UserStudentId",
                table: "UserPersonalInformation",
                column: "UserStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPersonalInformation_userStudents_UserStudentId",
                table: "UserPersonalInformation",
                column: "UserStudentId",
                principalTable: "userStudents",
                principalColumn: "Id");
        }
    }
}
