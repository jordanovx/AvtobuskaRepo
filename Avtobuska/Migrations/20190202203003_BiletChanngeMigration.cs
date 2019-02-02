using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtobuska.Migrations
{
    public partial class BiletChanngeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "Izdaden",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "Rezerviran",
                table: "Bilet");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumNaKupuvanje",
                table: "Bilet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumNaVazenje",
                table: "Bilet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumNaKupuvanje",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "DatumNaVazenje",
                table: "Bilet");

            migrationBuilder.AddColumn<decimal>(
                name: "Cena",
                table: "Bilet",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "Izdaden",
                table: "Bilet",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Rezerviran",
                table: "Bilet",
                nullable: false,
                defaultValue: false);
        }
    }
}
