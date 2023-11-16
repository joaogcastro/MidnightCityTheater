using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelAlterada10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Filme_FilmeId",
                table: "Sala");

            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala");

            migrationBuilder.DropIndex(
                name: "IX_Sala_FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Sala");

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
                name: "SalaIdSala",
                table: "Filme");

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Sala",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioIdFuncionario",
                table: "Sala",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Sala",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala",
                column: "FilmeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FuncionarioIdFuncionario",
                table: "Sala",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Filme_FilmeId",
                table: "Sala",
                column: "FilmeId",
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
