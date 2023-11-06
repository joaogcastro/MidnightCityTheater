using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAlteradas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmeIdFilme",
                table: "Ingresso",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFilme",
                table: "Ingresso",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Ingresso",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaIdSala",
                table: "Ingresso",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmeSala",
                columns: table => new
                {
                    FilmesIdFilme = table.Column<int>(type: "INTEGER", nullable: false),
                    SalasIdSala = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeSala", x => new { x.FilmesIdFilme, x.SalasIdSala });
                    table.ForeignKey(
                        name: "FK_FilmeSala_Filme_FilmesIdFilme",
                        column: x => x.FilmesIdFilme,
                        principalTable: "Filme",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmeSala_Sala_SalasIdSala",
                        column: x => x.SalasIdSala,
                        principalTable: "Sala",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_FilmeIdFilme",
                table: "Ingresso",
                column: "FilmeIdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_SalaIdSala",
                table: "Ingresso",
                column: "SalaIdSala");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeSala_SalasIdSala",
                table: "FilmeSala",
                column: "SalasIdSala");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Filme_FilmeIdFilme",
                table: "Ingresso",
                column: "FilmeIdFilme",
                principalTable: "Filme",
                principalColumn: "IdFilme");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Sala_SalaIdSala",
                table: "Ingresso",
                column: "SalaIdSala",
                principalTable: "Sala",
                principalColumn: "IdSala");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Filme_FilmeIdFilme",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Sala_SalaIdSala",
                table: "Ingresso");

            migrationBuilder.DropTable(
                name: "FilmeSala");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_FilmeIdFilme",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_SalaIdSala",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "FilmeIdFilme",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "IdFilme",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "SalaIdSala",
                table: "Ingresso");
        }
    }
}
