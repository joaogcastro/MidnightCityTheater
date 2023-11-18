using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelAlterada15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Filme_FilmeId",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_FilmeId",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "FilmeId",
                table: "Ingresso");

            migrationBuilder.AddColumn<int>(
                name: "FilmeIdFilme",
                table: "Ingresso",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_FilmeIdFilme",
                table: "Ingresso",
                column: "FilmeIdFilme");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Filme_FilmeIdFilme",
                table: "Ingresso",
                column: "FilmeIdFilme",
                principalTable: "Filme",
                principalColumn: "IdFilme");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Filme_FilmeIdFilme",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_FilmeIdFilme",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "FilmeIdFilme",
                table: "Ingresso");

            migrationBuilder.AddColumn<int>(
                name: "FilmeId",
                table: "Ingresso",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_FilmeId",
                table: "Ingresso",
                column: "FilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Filme_FilmeId",
                table: "Ingresso",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "IdFilme",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
