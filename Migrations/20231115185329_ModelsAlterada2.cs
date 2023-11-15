using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAlterada2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala");

            migrationBuilder.AddColumn<int>(
                name: "IdSala",
                table: "Filme",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala",
                column: "FilmeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala");

            migrationBuilder.DropColumn(
                name: "IdSala",
                table: "Filme");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FilmeId",
                table: "Sala",
                column: "FilmeId");
        }
    }
}
