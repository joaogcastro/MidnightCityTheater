using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAlteradas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Filme_FilmeIdFilme",
                table: "Sala");

            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Sala_FilmeIdFilme",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Sala_FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "FilmeIdFilme",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Filme",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalaIdSala",
                table: "Filme",
                type: "INTEGER",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Sala_SalaIdSala",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_SalaIdSala",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "SalaIdSala",
                table: "Filme");

            migrationBuilder.AddColumn<int>(
                name: "FilmeIdFilme",
                table: "Sala",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioIdFuncionario",
                table: "Sala",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FilmeIdFilme",
                table: "Sala",
                column: "FilmeIdFilme");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FuncionarioIdFuncionario",
                table: "Sala",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Filme_FilmeIdFilme",
                table: "Sala",
                column: "FilmeIdFilme",
                principalTable: "Filme",
                principalColumn: "IdFilme");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                table: "Sala",
                column: "FuncionarioIdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario");
        }
    }
}
