using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrationexamtest123456789 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    cin = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.cin);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "avocats",
                columns: table => new
                {
                    avocatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    specialiteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avocats", x => x.avocatId);
                    table.ForeignKey(
                        name: "FK_avocats_Specialite_specialiteFk",
                        column: x => x.specialiteFk,
                        principalTable: "Specialite",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "dossiers",
                columns: table => new
                {
                    dateDepot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clientFk = table.Column<int>(type: "int", nullable: false),
                    avocatFk = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frais = table.Column<float>(type: "real", nullable: false),
                    clos = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dossiers", x => new { x.clientFk, x.avocatFk, x.dateDepot });
                    table.ForeignKey(
                        name: "FK_dossiers_avocats_avocatFk",
                        column: x => x.avocatFk,
                        principalTable: "avocats",
                        principalColumn: "avocatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dossiers_clients_clientFk",
                        column: x => x.clientFk,
                        principalTable: "clients",
                        principalColumn: "cin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_avocats_specialiteFk",
                table: "avocats",
                column: "specialiteFk");

            migrationBuilder.CreateIndex(
                name: "IX_dossiers_avocatFk",
                table: "dossiers",
                column: "avocatFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dossiers");

            migrationBuilder.DropTable(
                name: "avocats");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "Specialite");

            migrationBuilder.CreateTable(
                name: "Mannequins",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    NombreAnnéesExpérience = table.Column<int>(type: "int", nullable: false),
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
                    StylisteFK = table.Column<int>(type: "int", nullable: false),
                    DateEvennement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    MannequinId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefileId = table.Column<int>(type: "int", nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affectations", x => new { x.MannequinId, x.DefileId, x.DateEnvoi });
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
                    DefileFK = table.Column<int>(type: "int", nullable: false),
                    Couleur = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Matiere = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrixUnitaireFabrication = table.Column<float>(type: "real", nullable: false),
                    PrixUnitaireVente = table.Column<float>(type: "real", nullable: false),
                    nbAccessoires = table.Column<int>(type: "int", nullable: false)
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
    }
}
