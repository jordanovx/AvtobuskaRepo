using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtobuska.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Linii",
                table: "Bilet");

            migrationBuilder.RenameColumn(
                name: "BrojNaSedista",
                table: "Bilet",
                newName: "SedisteBroj");

            migrationBuilder.AlterColumn<bool>(
                name: "Rezerviran",
                table: "Bilet",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "Izdaden",
                table: "Bilet",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BrojNaSediste",
                table: "Bilet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LinijaID",
                table: "Bilet",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Prevoznik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prevoznik", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Linija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    VremeNaTrgnuvanje = table.Column<DateTime>(nullable: false),
                    PrevoznikID = table.Column<int>(nullable: false),
                    StanicaID = table.Column<int>(nullable: false),
                    BrojNaSedista = table.Column<int>(nullable: false),
                    Peron = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Linija_Prevoznik_PrevoznikID",
                        column: x => x.PrevoznikID,
                        principalTable: "Prevoznik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bilet_LinijaID",
                table: "Bilet",
                column: "LinijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Linija_PrevoznikID",
                table: "Linija",
                column: "PrevoznikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilet_Linija_LinijaID",
                table: "Bilet",
                column: "LinijaID",
                principalTable: "Linija",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilet_Linija_LinijaID",
                table: "Bilet");

            migrationBuilder.DropTable(
                name: "Linija");

            migrationBuilder.DropTable(
                name: "Prevoznik");

            migrationBuilder.DropIndex(
                name: "IX_Bilet_LinijaID",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "BrojNaSediste",
                table: "Bilet");

            migrationBuilder.DropColumn(
                name: "LinijaID",
                table: "Bilet");

            migrationBuilder.RenameColumn(
                name: "SedisteBroj",
                table: "Bilet",
                newName: "BrojNaSedista");

            migrationBuilder.AlterColumn<int>(
                name: "Rezerviran",
                table: "Bilet",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "Izdaden",
                table: "Bilet",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<string>(
                name: "Linii",
                table: "Bilet",
                nullable: true);
        }
    }
}
