using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAlteradas4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Sala_SalaIdSala",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Filme_FilmeId",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Filme_SalaIdSala",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "SalaIdSala",
                table: "Filme");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_SalaId",
                table: "Filme",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Sala_SalaId",
                table: "Filme",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "IdSala",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Sala_SalaId",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_SalaId",
                table: "Filme");

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Sala",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaIdSala",
                table: "Filme",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_SalaIdSala",
                table: "Filme",
                column: "SalaIdSala");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Sala_SalaIdSala",
                table: "Filme",
                column: "SalaIdSala",
                principalTable: "Sala",
                principalColumn: "IdSala");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Filme_FilmeId",
                table: "Sala",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "IdFilme");
        }
    }
}
