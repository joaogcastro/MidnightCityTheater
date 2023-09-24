using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiFindWorks.Migrations
{
    /// <inheritdoc />
    public partial class AlteracaoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Profissional_ProfissionalId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ProfissionalId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ProfissionalId",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfissionalId",
                table: "Usuario",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ProfissionalId",
                table: "Usuario",
                column: "ProfissionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Profissional_ProfissionalId",
                table: "Usuario",
                column: "ProfissionalId",
                principalTable: "Profissional",
                principalColumn: "Id");
        }
    }
}
