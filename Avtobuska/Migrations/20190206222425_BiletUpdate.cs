using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtobuska.Migrations
{
    public partial class BiletUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cena",
                table: "Bilet",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DestinacijaID",
                table: "Bilet",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Povraten",
                table: "Bilet",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_DestinacijaID",
                table: "Bilet",
                column: "DestinacijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilet_Stanica_DestinacijaID",
                table: "Bilet",
                column: "DestinacijaID",
                principalTable: "Stanica",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilet_Stanica_DestinacijaID",
                table: "Bilet");

            migrationBuilder.DropIndex(
                name: "IX_Bilet_DestinacijaID",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "DestinacijaID",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "Povraten",
                table: "Bilet");
        }
    }
}
