using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig988 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "Tel",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "prenom",
                table: "clients");

            migrationBuilder.AddColumn<string>(
                name: "CoordonneesTel",
                table: "clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Coordonnees",
                columns: table => new
                {
                    Tel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordonnees", x => x.Tel);
                });

            migrationBuilder.CreateIndex(
                name: "IX_clients_CoordonneesTel",
                table: "clients",
                column: "CoordonneesTel");

            migrationBuilder.AddForeignKey(
                name: "FK_clients_Coordonnees_CoordonneesTel",
                table: "clients",
                column: "CoordonneesTel",
                principalTable: "Coordonnees",
                principalColumn: "Tel",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_clients_Coordonnees_CoordonneesTel",
                table: "clients");

            migrationBuilder.DropTable(
                name: "Coordonnees");

            migrationBuilder.DropIndex(
                name: "IX_clients_CoordonneesTel",
                table: "clients");

            migrationBuilder.DropColumn(
                name: "CoordonneesTel",
                table: "clients");

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "prenom",
                table: "clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
