using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessionIdInUserWorkTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "userWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userWorks_ProfessionId",
                table: "userWorks",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_userWorks_professions_ProfessionId",
                table: "userWorks",
                column: "ProfessionId",
                principalTable: "professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userWorks_professions_ProfessionId",
                table: "userWorks");

            migrationBuilder.DropIndex(
                name: "IX_userWorks_ProfessionId",
                table: "userWorks");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "userWorks");
        }
    }
}
