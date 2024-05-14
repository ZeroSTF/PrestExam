using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Affectations",
                table: "Affectations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Affectations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Affectations",
                table: "Affectations",
                columns: new[] { "MannequinId", "DefileId", "DateEnvoi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Affectations",
                table: "Affectations");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Affectations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Affectations",
                table: "Affectations",
                columns: new[] { "MannequinId", "DefileId", "Id" });
        }
    }
}
