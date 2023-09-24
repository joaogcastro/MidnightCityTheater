using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiFindWorks.Migrations
{
    /// <inheritdoc />
    public partial class Alteracao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Distancia",
                table: "Profissional",
                newName: "DistanciaDoCentro");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Profissional",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Profissional",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Profissional");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Profissional");

            migrationBuilder.RenameColumn(
                name: "DistanciaDoCentro",
                table: "Profissional",
                newName: "Distancia");
        }
    }
}
