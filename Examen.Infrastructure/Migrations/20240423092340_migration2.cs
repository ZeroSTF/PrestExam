using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mannequins",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NumContract = table.Column<int>(type: "int", nullable: false),
                    Poid = table.Column<float>(type: "real", nullable: false),
                    PrixParHeure = table.Column<float>(type: "real", nullable: false),
                    Taille = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mannequins", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "StylisteModelistes",
                columns: table => new
                {
                    StylistCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telephone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StylisteModelistes", x => x.StylistCode);
                });

            migrationBuilder.CreateTable(
                name: "Defiles",
                columns: table => new
                {
                    DefileCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEvennement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StylisteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defiles", x => x.DefileCode);
                    table.ForeignKey(
                        name: "FK_Defiles_StylisteModelistes_StylisteFK",
                        column: x => x.StylisteFK,
                        principalTable: "StylisteModelistes",
                        principalColumn: "StylistCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Affectations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MannequinId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefileId = table.Column<int>(type: "int", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affectations", x => new { x.MannequinId, x.DefileId, x.Id });
                    table.ForeignKey(
                        name: "FK_Affectations_Defiles_DefileId",
                        column: x => x.DefileId,
                        principalTable: "Defiles",
                        principalColumn: "DefileCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Affectations_Mannequins_MannequinId",
                        column: x => x.MannequinId,
                        principalTable: "Mannequins",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Couleur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Matiere = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nbAccessoires = table.Column<int>(type: "int", nullable: false),
                    PrixUnitaireFabrication = table.Column<float>(type: "real", nullable: false),
                    PrixUnitaireVente = table.Column<float>(type: "real", nullable: false),
                    DefileFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleCode);
                    table.ForeignKey(
                        name: "FK_Articles_Defiles_DefileFK",
                        column: x => x.DefileFK,
                        principalTable: "Defiles",
                        principalColumn: "DefileCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_DefileId",
                table: "Affectations",
                column: "DefileId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_DefileFK",
                table: "Articles",
                column: "DefileFK");

            migrationBuilder.CreateIndex(
                name: "IX_Defiles_StylisteFK",
                table: "Defiles",
                column: "StylisteFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affectations");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Mannequins");

            migrationBuilder.DropTable(
                name: "Defiles");

            migrationBuilder.DropTable(
                name: "StylisteModelistes");
        }
    }
}
