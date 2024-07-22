using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class passuserpersonlinregister : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPersonalInformation_UserId",
                table: "UserPersonalInformation");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalInformation_UserId",
                table: "UserPersonalInformation",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPersonalInformation_UserId",
                table: "UserPersonalInformation");

            migrationBuilder.CreateIndex(
                name: "IX_UserPersonalInformation_UserId",
                table: "UserPersonalInformation",
                column: "UserId");
        }
    }
}
