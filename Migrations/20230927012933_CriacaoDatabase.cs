using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    IdFilme = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFilme = table.Column<string>(type: "TEXT", nullable: false),
                    Duracao = table.Column<string>(type: "TEXT", nullable: false),
                    Classificacao = table.Column<string>(type: "TEXT", nullable: false),
                    Diretor = table.Column<string>(type: "TEXT", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.IdFilme);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngressoId = table.Column<int>(type: "INTEGER", nullable: false),
                    SnackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.IdVenda);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuncionarioIdFuncionario = table.Column<int>(type: "INTEGER", nullable: false),
                    Capacidade = table.Column<string>(type: "TEXT", nullable: false),
                    TipoSala = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IdSala);
                    table.ForeignKey(
                        name: "FK_Sala_Funcionario_FuncionarioIdFuncionario",
                        column: x => x.FuncionarioIdFuncionario,
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    VendaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingresso",
                columns: table => new
                {
                    IdIngresso = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoIngresso = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<string>(type: "TEXT", nullable: false),
                    VendaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresso", x => x.IdIngresso);
                    table.ForeignKey(
                        name: "FK_Ingresso_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    IdSnack = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VendaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.IdSnack);
                    table.ForeignKey(
                        name: "FK_Snack_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bebida",
                columns: table => new
                {
                    IdBebida = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sabor = table.Column<string>(type: "TEXT", nullable: false),
                    Tamanho = table.Column<string>(type: "TEXT", nullable: false),
                    SnackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebida", x => x.IdBebida);
                    table.ForeignKey(
                        name: "FK_Bebida_Snack_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snack",
                        principalColumn: "IdSnack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doce",
                columns: table => new
                {
                    IdDoce = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    SnackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doce", x => x.IdDoce);
                    table.ForeignKey(
                        name: "FK_Doce_Snack_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snack",
                        principalColumn: "IdSnack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pipoca",
                columns: table => new
                {
                    IdPipoca = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sabor = table.Column<string>(type: "TEXT", nullable: false),
                    Tamanho = table.Column<string>(type: "TEXT", nullable: false),
                    SnackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipoca", x => x.IdPipoca);
                    table.ForeignKey(
                        name: "FK_Pipoca_Snack_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snack",
                        principalColumn: "IdSnack",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bebida_SnackId",
                table: "Bebida",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CPF",
                table: "Cliente",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_VendaId",
                table: "Cliente",
                column: "VendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doce_SnackId",
                table: "Doce",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_VendaId",
                table: "Ingresso",
                column: "VendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pipoca_SnackId",
                table: "Pipoca",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_FuncionarioIdFuncionario",
                table: "Sala",
                column: "FuncionarioIdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_Snack_VendaId",
                table: "Snack",
                column: "VendaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebida");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Doce");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Ingresso");

            migrationBuilder.DropTable(
                name: "Pipoca");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Snack");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Venda");
        }
    }
}
