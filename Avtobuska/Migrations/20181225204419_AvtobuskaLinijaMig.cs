using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtobuska.Migrations
{
    public partial class AvtobuskaLinijaMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenaNaEdenPravec",
                table: "Linija");

            migrationBuilder.DropColumn(
                name: "CenaNaPovraten",
                table: "Linija");

            migrationBuilder.AddColumn<decimal>(
                name: "CenaNaEdenPravec",
                table: "Stanica",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CenaNaPovraten",
                table: "Stanica",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenaNaEdenPravec",
                table: "Stanica");

            migrationBuilder.DropColumn(
                name: "CenaNaPovraten",
                table: "Stanica");

            migrationBuilder.AddColumn<decimal>(
                name: "CenaNaEdenPravec",
                table: "Linija",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CenaNaPovraten",
                table: "Linija",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
