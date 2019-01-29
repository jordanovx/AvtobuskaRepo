using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Avtobuska.Migrations
{
    public partial class StanicaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stanica",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MestoID = table.Column<int>(nullable: false),
                    CenaNaEdenPravec = table.Column<decimal>(nullable: false),
                    CenaNaPovraten = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanica", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stanica_Mesto_MestoID",
                        column: x => x.MestoID,
                        principalTable: "Mesto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stanica_MestoID",
                table: "Stanica",
                column: "MestoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stanica");

            migrationBuilder.DropTable(
                name: "Mesto");
        }
    }
}
