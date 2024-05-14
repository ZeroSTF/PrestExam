using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig987 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contrats");

            migrationBuilder.DropTable(
                name: "trophees");

            migrationBuilder.DropTable(
                name: "membres");

            migrationBuilder.DropTable(
                name: "equipes");

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "specialites",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intitule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialites", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "prestataires",
                columns: table => new
                {
                    PrestataireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appreciation = table.Column<int>(type: "int", nullable: false),
                    PrestataireNom = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PrestatairePhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrestataireTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifHoraire = table.Column<double>(type: "float", nullable: false),
                    SpecialiteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestataires", x => x.PrestataireId);
                    table.ForeignKey(
                        name: "FK_prestataires_specialites_SpecialiteFK",
                        column: x => x.SpecialiteFK,
                        principalTable: "specialites",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "prestations",
                columns: table => new
                {
                    HeureRDV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientFK = table.Column<int>(type: "int", nullable: false),
                    PrestataireFK = table.Column<int>(type: "int", nullable: false),
                    NbrHeures = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prestations", x => new { x.ClientFK, x.PrestataireFK, x.HeureRDV });
                    table.ForeignKey(
                        name: "FK_prestations_clients_ClientFK",
                        column: x => x.ClientFK,
                        principalTable: "clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_prestations_prestataires_PrestataireFK",
                        column: x => x.PrestataireFK,
                        principalTable: "prestataires",
                        principalColumn: "PrestataireId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prestataires_SpecialiteFK",
                table: "prestataires",
                column: "SpecialiteFK");

            migrationBuilder.CreateIndex(
                name: "IX_prestations_PrestataireFK",
                table: "prestations",
                column: "PrestataireFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prestations");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "prestataires");

            migrationBuilder.DropTable(
                name: "specialites");

            migrationBuilder.CreateTable(
                name: "equipes",
                columns: table => new
                {
                    equipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adresseLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomEquipe = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipes", x => x.equipeId);
                });

            migrationBuilder.CreateTable(
                name: "membres",
                columns: table => new
                {
                    identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: true),
                    poste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membres", x => x.identifiant);
                });

            migrationBuilder.CreateTable(
                name: "trophees",
                columns: table => new
                {
                    tropheeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipeFk = table.Column<int>(type: "int", nullable: false),
                    dateTrophee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    recompense = table.Column<double>(type: "float", nullable: false),
                    typeTrophee = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trophees", x => x.tropheeId);
                    table.ForeignKey(
                        name: "FK_trophees_equipes_equipeFk",
                        column: x => x.equipeFk,
                        principalTable: "equipes",
                        principalColumn: "equipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contrats",
                columns: table => new
                {
                    equipeFk = table.Column<int>(type: "int", nullable: false),
                    membreFk = table.Column<int>(type: "int", nullable: false),
                    dateContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dureeMois = table.Column<int>(type: "int", nullable: false),
                    salaire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrats", x => new { x.equipeFk, x.membreFk, x.dateContrat });
                    table.ForeignKey(
                        name: "FK_contrats_equipes_equipeFk",
                        column: x => x.equipeFk,
                        principalTable: "equipes",
                        principalColumn: "equipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contrats_membres_membreFk",
                        column: x => x.membreFk,
                        principalTable: "membres",
                        principalColumn: "identifiant",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_contrats_membreFk",
                table: "contrats",
                column: "membreFk");

            migrationBuilder.CreateIndex(
                name: "IX_trophees_equipeFk",
                table: "trophees",
                column: "equipeFk");
        }
    }
}
