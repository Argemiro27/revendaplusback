using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace revendaplus_back.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    taxa_lucro = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    preco_unit_compra = table.Column<float>(type: "real", maxLength: 15, nullable: false),
                    preco_venda = table.Column<float>(type: "real", maxLength: 15, nullable: false),
                    preco_total_compra = table.Column<float>(type: "real", maxLength: 100, nullable: false),
                    data_hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nome_produto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sku = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    quant_vendida = table.Column<int>(type: "int", nullable: false),
                    data_hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ItensEstoque",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    quant_estoque = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensEstoque", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItensEstoque_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensEstoque_id_produto",
                table: "ItensEstoque",
                column: "id_produto",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensEstoque");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
