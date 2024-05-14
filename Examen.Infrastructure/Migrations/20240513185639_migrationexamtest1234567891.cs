using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrationexamtest1234567891 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Membre",
                columns: table => new
                {
                    identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    grade = table.Column<int>(type: "int", nullable: true),
                    poste = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membre", x => x.identifiant);
                });

            migrationBuilder.CreateTable(
                name: "trophees",
                columns: table => new
                {
                    tropheeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTrophee = table.Column<DateTime>(type: "datetime2", nullable: false),
                    recompense = table.Column<double>(type: "float", nullable: false),
                    typeTrophee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    equipeFk = table.Column<int>(type: "int", nullable: false)
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
                    dateContrat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    equipeFk = table.Column<int>(type: "int", nullable: false),
                    membreFk = table.Column<int>(type: "int", nullable: false),
                    dureeMois = table.Column<int>(type: "int", nullable: false),
                    salaire = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contrats", x => new { x.equipeFk, x.membreFk, x.dateContrat });
                    table.ForeignKey(
                        name: "FK_contrats_Membre_membreFk",
                        column: x => x.membreFk,
                        principalTable: "Membre",
                        principalColumn: "identifiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contrats_equipes_equipeFk",
                        column: x => x.equipeFk,
                        principalTable: "equipes",
                        principalColumn: "equipeId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contrats");

            migrationBuilder.DropTable(
                name: "trophees");

            migrationBuilder.DropTable(
                name: "Membre");

            migrationBuilder.DropTable(
                name: "equipes");

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
                    specialiteFk = table.Column<int>(type: "int", nullable: false),
                    dateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    clientFk = table.Column<int>(type: "int", nullable: false),
                    avocatFk = table.Column<int>(type: "int", nullable: false),
                    dateDepot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clos = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    frais = table.Column<float>(type: "real", nullable: false)
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
    }
}
