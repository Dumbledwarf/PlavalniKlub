using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bazen",
                columns: table => new
                {
                    BazenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bazen", x => x.BazenID);
                });

            migrationBuilder.CreateTable(
                name: "Ucitelj",
                columns: table => new
                {
                    UciteljID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRojstva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrnaPostavka = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucitelj", x => x.UciteljID);
                });

            migrationBuilder.CreateTable(
                name: "Skupine",
                columns: table => new
                {
                    SkupinaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UciteljID = table.Column<int>(type: "int", nullable: false),
                    BazenID = table.Column<int>(type: "int", nullable: false),
                    ProgaID = table.Column<int>(type: "int", nullable: false),
                    Ura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skupine", x => x.SkupinaID);
                    table.ForeignKey(
                        name: "FK_Skupine_Bazen_BazenID",
                        column: x => x.BazenID,
                        principalTable: "Bazen",
                        principalColumn: "BazenID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Skupine_Ucitelj_UciteljID",
                        column: x => x.UciteljID,
                        principalTable: "Ucitelj",
                        principalColumn: "UciteljID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izvedba",
                columns: table => new
                {
                    IzvedbaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SkupinaID = table.Column<int>(type: "int", nullable: false),
                    NadomestniUciteljID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvedba", x => x.IzvedbaID);
                    table.ForeignKey(
                        name: "FK_Izvedba_Skupine_SkupinaID",
                        column: x => x.SkupinaID,
                        principalTable: "Skupine",
                        principalColumn: "SkupinaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izvedba_Ucitelj_NadomestniUciteljID",
                        column: x => x.NadomestniUciteljID,
                        principalTable: "Ucitelj",
                        principalColumn: "UciteljID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Plavalec",
                columns: table => new
                {
                    PlavalecID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRojstva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SkupinaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plavalec", x => x.PlavalecID);
                    table.ForeignKey(
                        name: "FK_Plavalec_Skupine_SkupinaID",
                        column: x => x.SkupinaID,
                        principalTable: "Skupine",
                        principalColumn: "SkupinaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_NadomestniUciteljID",
                table: "Izvedba",
                column: "NadomestniUciteljID");

            migrationBuilder.CreateIndex(
                name: "IX_Izvedba_SkupinaID",
                table: "Izvedba",
                column: "SkupinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Plavalec_SkupinaID",
                table: "Plavalec",
                column: "SkupinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Skupine_BazenID",
                table: "Skupine",
                column: "BazenID");

            migrationBuilder.CreateIndex(
                name: "IX_Skupine_UciteljID",
                table: "Skupine",
                column: "UciteljID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Izvedba");

            migrationBuilder.DropTable(
                name: "Plavalec");

            migrationBuilder.DropTable(
                name: "Skupine");

            migrationBuilder.DropTable(
                name: "Bazen");

            migrationBuilder.DropTable(
                name: "Ucitelj");
        }
    }
}
