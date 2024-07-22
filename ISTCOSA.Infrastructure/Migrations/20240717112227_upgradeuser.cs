using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISTCOSA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class upgradeuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "childrenDetails");

            migrationBuilder.AddColumn<string>(
                name: "FamilyDetails",
                table: "UserPersonalInformation",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyDetails",
                table: "UserPersonalInformation");

            migrationBuilder.CreateTable(
                name: "childrenDetails",
                columns: table => new
                {
                    SNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPersonalInformationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_childrenDetails", x => x.SNo);
                    table.ForeignKey(
                        name: "FK_childrenDetails_UserPersonalInformation_UserPersonalInformationId",
                        column: x => x.UserPersonalInformationId,
                        principalTable: "UserPersonalInformation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_childrenDetails_UserPersonalInformationId",
                table: "childrenDetails",
                column: "UserPersonalInformationId");
        }
    }
}
