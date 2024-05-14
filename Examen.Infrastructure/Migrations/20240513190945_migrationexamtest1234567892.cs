using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrationexamtest1234567892 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrats_Membre_membreFk",
                table: "contrats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Membre",
                table: "Membre");

            migrationBuilder.RenameTable(
                name: "Membre",
                newName: "membres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_membres",
                table: "membres",
                column: "identifiant");

            migrationBuilder.AddForeignKey(
                name: "FK_contrats_membres_membreFk",
                table: "contrats",
                column: "membreFk",
                principalTable: "membres",
                principalColumn: "identifiant",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contrats_membres_membreFk",
                table: "contrats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_membres",
                table: "membres");

            migrationBuilder.RenameTable(
                name: "membres",
                newName: "Membre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Membre",
                table: "Membre",
                column: "identifiant");

            migrationBuilder.AddForeignKey(
                name: "FK_contrats_Membre_membreFk",
                table: "contrats",
                column: "membreFk",
                principalTable: "Membre",
                principalColumn: "identifiant",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
