using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class certo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Venda",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngressoIdIngresso",
                table: "Venda",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendaIdVenda",
                table: "Filme",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteIdCliente",
                table: "Venda",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_IngressoIdIngresso",
                table: "Venda",
                column: "IngressoIdIngresso");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Venda_Cliente_ClienteIdCliente",
                table: "Venda",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente");

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
                name: "FK_Filme_Venda_VendaIdVenda",
                table: "Filme");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Cliente_ClienteIdCliente",
                table: "Venda");

            migrationBuilder.DropForeignKey(
                name: "FK_Venda_Ingresso_IngressoIdIngresso",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_ClienteIdCliente",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Venda_IngressoIdIngresso",
                table: "Venda");

            migrationBuilder.DropIndex(
                name: "IX_Filme_VendaIdVenda",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "IngressoIdIngresso",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "VendaIdVenda",
                table: "Filme");
        }
    }
}
