using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevIO.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbAvulsos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: false),
                    HrEntrada = table.Column<DateTime>(nullable: false),
                    HrSaida = table.Column<DateTime>(nullable: false),
                    PrecoFinal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbAvulsos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbMensais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    ValidadeContrato = table.Column<DateTime>(nullable: false),
                    ValorPrecoMensal = table.Column<double>(nullable: false),
                    DataPagamento = table.Column<DateTime>(nullable: false),
                    ValorMulta = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbMensais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPrecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    NomeTipoPreco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPrecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCarros",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    MensalId = table.Column<Guid>(nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: false),
                    Cor = table.Column<string>(nullable: true),
                    TipoVeiculo = table.Column<int>(type: "int", nullable: false),
                    Tamanho = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCarros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCarros_TbMensais_MensalId",
                        column: x => x.MensalId,
                        principalTable: "TbMensais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbClientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    MensalId = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Endereco = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbClientes_TbMensais_MensalId",
                        column: x => x.MensalId,
                        principalTable: "TbMensais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbPagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    MensalId = table.Column<Guid>(nullable: false),
                    MesPagamento = table.Column<int>(nullable: false),
                    PagamentoRealizado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPagamentos_TbMensais_MensalId",
                        column: x => x.MensalId,
                        principalTable: "TbMensais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbCarros_MensalId",
                table: "TbCarros",
                column: "MensalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbClientes_MensalId",
                table: "TbClientes",
                column: "MensalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbPagamentos_MensalId",
                table: "TbPagamentos",
                column: "MensalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbAvulsos");

            migrationBuilder.DropTable(
                name: "TbCarros");

            migrationBuilder.DropTable(
                name: "TbClientes");

            migrationBuilder.DropTable(
                name: "TbPagamentos");

            migrationBuilder.DropTable(
                name: "TbPrecos");

            migrationBuilder.DropTable(
                name: "TbMensais");
        }
    }
}
