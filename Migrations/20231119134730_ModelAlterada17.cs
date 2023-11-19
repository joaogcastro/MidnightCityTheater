using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelAlterada17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VendaIdVenda",
                table: "Filme",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filme_VendaIdVenda",
                table: "Filme",
                column: "VendaIdVenda");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Venda_VendaIdVenda",
                table: "Filme",
                column: "VendaIdVenda",
                principalTable: "Venda",
                principalColumn: "IdVenda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Venda_VendaIdVenda",
                table: "Filme");

            migrationBuilder.DropIndex(
                name: "IX_Filme_VendaIdVenda",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "VendaIdVenda",
                table: "Filme");
        }
    }
}
