using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class ModelAlterada13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Venda_VendaId",
                table: "Ingresso");

            migrationBuilder.DropIndex(
                name: "IX_Ingresso_VendaId",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Ingresso");

            migrationBuilder.DropColumn(
                name: "VendaId",
                table: "Ingresso");

            migrationBuilder.AddColumn<int>(
                name: "IngressoIdIngresso",
                table: "Venda",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecoIng",
                table: "Ingresso",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_IngressoIdIngresso",
                table: "Venda",
                column: "IngressoIdIngresso");

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Ingresso_IngressoIdIngresso",
                table: "Venda",
                column: "IngressoIdIngresso",
                principalTable: "Ingresso",
                principalColumn: "IdIngresso");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Ingresso_IngressoIdIngresso",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_IngressoIdIngresso",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "IngressoIdIngresso",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "PrecoIng",
                table: "Ingresso");

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Ingresso",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Preco",
                table: "Ingresso",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendaId",
                table: "Ingresso",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_VendaId",
                table: "Ingresso",
                column: "VendaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Venda_VendaId",
                table: "Ingresso",
                column: "VendaId",
                principalTable: "Venda",
                principalColumn: "IdVenda",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
