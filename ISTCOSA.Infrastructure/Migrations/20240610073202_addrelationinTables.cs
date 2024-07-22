using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addrelationinTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "userWorks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_userWorks_CompanyId",
                table: "userWorks",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_userWorks_companies_CompanyId",
                table: "userWorks",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userWorks_companies_CompanyId",
                table: "userWorks");

            migrationBuilder.DropIndex(
                name: "IX_userWorks_CompanyId",
                table: "userWorks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "userWorks");
        }
    }
}
