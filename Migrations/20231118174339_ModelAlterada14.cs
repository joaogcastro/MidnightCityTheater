using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelAlterada14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Sala_SalaId",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_SalaId",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "SalaId",
                table: "Ingresso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalaId",
                table: "Ingresso",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_SalaId",
                table: "Ingresso",
                column: "SalaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Sala_SalaId",
                table: "Ingresso",
                column: "SalaId",
                principalTable: "Sala",
                principalColumn: "IdSala",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
