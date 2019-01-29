using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtobuska.Migrations
{
    public partial class AvtobuskaLinijaMig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StanicaID",
                table: "Linija");

            migrationBuilder.AddColumn<int>(
                name: "LinijaID",
                table: "Stanica",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stanica_LinijaID",
                table: "Stanica",
                column: "LinijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stanica_Linija_LinijaID",
                table: "Stanica",
                column: "LinijaID",
                principalTable: "Linija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stanica_Linija_LinijaID",
                table: "Stanica");

            migrationBuilder.DropIndex(
                name: "IX_Stanica_LinijaID",
                table: "Stanica");

            migrationBuilder.DropColumn(
                name: "LinijaID",
                table: "Stanica");

            migrationBuilder.AddColumn<int>(
                name: "StanicaID",
                table: "Linija",
                nullable: false,
                defaultValue: 0);
        }
    }
}
