using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoFuncionario1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Funcionario",
                newName: "TelefoneFunc");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Funcionario",
                newName: "NomeFunc");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Funcionario",
                newName: "EmailFunc");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Funcionario",
                newName: "CPFfunc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelefoneFunc",
                table: "Funcionario",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "NomeFunc",
                table: "Funcionario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "EmailFunc",
                table: "Funcionario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "CPFfunc",
                table: "Funcionario",
                newName: "CPF");
        }
    }
}
