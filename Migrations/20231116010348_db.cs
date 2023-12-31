﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MidnightCityTheater.Migrations
{
    /// <inheritdoc />
    public partial class db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPF = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Telefone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CPFfunc = table.Column<string>(type: "TEXT", nullable: false),
                    NomeFunc = table.Column<string>(type: "TEXT", nullable: false),
                    EmailFunc = table.Column<string>(type: "TEXT", nullable: true),
                    TelefoneFunc = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IdSala = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Capacidade = table.Column<string>(type: "TEXT", nullable: false),
                    TipoSala = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IdSala);
                });

            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    IdSnack = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PrecoTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.IdSnack);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    IdFilme = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeFilme = table.Column<string>(type: "TEXT", nullable: false),
                    Duracao = table.Column<string>(type: "TEXT", nullable: false),
                    Classificacao = table.Column<string>(type: "TEXT", nullable: true),
                    Diretor = table.Column<string>(type: "TEXT", nullable: true),
                    Categoria = table.Column<string>(type: "TEXT", nullable: true),
                    IdSala = table.Column<int>(type: "INTEGER", nullable: true),
                    SalaIdSala = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.IdFilme);
                    table.ForeignKey(
                        name: "FK_Filme_Sala_SalaIdSala",
                        column: x => x.SalaIdSala,
                        principalTable: "Sala",
                        principalColumn: "IdSala");
                });

            migrationBuilder.CreateTable(
                name: "Bebida",
                columns: table => new
                {
                    IdBebida = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sabor = table.Column<string>(type: "TEXT", nullable: false),
                    Tamanho = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<double>(type: "REAL", nullable: false),
                    SnackIdSnack = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebida", x => x.IdBebida);
                    table.ForeignKey(
                        name: "FK_Bebida_Snack_SnackIdSnack",
                        column: x => x.SnackIdSnack,
                        principalTable: "Snack",
                        principalColumn: "IdSnack");
                });

            migrationBuilder.CreateTable(
                name: "Doce",
                columns: table => new
                {
                    IdDoce = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<double>(type: "REAL", nullable: false),
                    SnackIdSnack = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doce", x => x.IdDoce);
                    table.ForeignKey(
                        name: "FK_Doce_Snack_SnackIdSnack",
                        column: x => x.SnackIdSnack,
                        principalTable: "Snack",
                        principalColumn: "IdSnack");
                });

            migrationBuilder.CreateTable(
                name: "Pipoca",
                columns: table => new
                {
                    IdPipoca = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sabor = table.Column<string>(type: "TEXT", nullable: false),
                    Tamanho = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<double>(type: "REAL", nullable: false),
                    SnackIdSnack = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipoca", x => x.IdPipoca);
                    table.ForeignKey(
                        name: "FK_Pipoca_Snack_SnackIdSnack",
                        column: x => x.SnackIdSnack,
                        principalTable: "Snack",
                        principalColumn: "IdSnack");
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    IdVenda = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "INTEGER", nullable: true),
                    SnackIdSnack = table.Column<int>(type: "INTEGER", nullable: true),
                    PrecoTotalVenda = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.IdVenda);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                    table.ForeignKey(
                        name: "FK_Venda_Snack_SnackIdSnack",
                        column: x => x.SnackIdSnack,
                        principalTable: "Snack",
                        principalColumn: "IdSnack");
                });

            migrationBuilder.CreateTable(
                name: "Ingresso",
                columns: table => new
                {
                    IdIngresso = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoIngresso = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    FilmeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SalaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Preco = table.Column<string>(type: "TEXT", nullable: true),
                    VendaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresso", x => x.IdIngresso);
                    table.ForeignKey(
                        name: "FK_Ingresso_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "IdFilme",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingresso_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "IdSala",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingresso_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "IdVenda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bebida_SnackIdSnack",
                table: "Bebida",
                column: "SnackIdSnack");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CPF",
                table: "Cliente",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doce_SnackIdSnack",
                table: "Doce",
                column: "SnackIdSnack");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_SalaIdSala",
                table: "Filme",
                column: "SalaIdSala");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_FilmeId",
                table: "Ingresso",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_SalaId",
                table: "Ingresso",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_VendaId",
                table: "Ingresso",
                column: "VendaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pipoca_SnackIdSnack",
                table: "Pipoca",
                column: "SnackIdSnack");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteIdCliente",
                table: "Venda",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_SnackIdSnack",
                table: "Venda",
                column: "SnackIdSnack");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebida");

            migrationBuilder.DropTable(
                name: "Doce");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Ingresso");

            migrationBuilder.DropTable(
                name: "Pipoca");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Snack");
        }
    }
}
