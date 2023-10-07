using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioIdFuncionario",
                table: "Sala",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Pipoca",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Preco",
                table: "Ingresso",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Diretor",
                table: "Filme",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Classificacao",
                table: "Filme",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Filme",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Doce",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Preco",
                table: "Bebida",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                table: "Sala",
                column: "FuncionarioIdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Pipoca");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Doce");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Bebida");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioIdFuncionario",
                table: "Sala",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Preco",
                table: "Ingresso",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diretor",
                table: "Filme",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Classificacao",
                table: "Filme",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Categoria",
                table: "Filme",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                table: "Sala",
                column: "FuncionarioIdFuncionario",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
