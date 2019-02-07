using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaParcial.Data.Migrations
{
    public partial class RealizarPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealizarPedido",
                columns: table => new
                {
                    idPedido = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    idCliente = table.Column<int>(nullable: false),
                    idPedidos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealizarPedido", x => x.idPedido);
                    table.ForeignKey(
                        name: "FK_RealizarPedido_Cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealizarPedido_Pedidos_idPedidos",
                        column: x => x.idPedidos,
                        principalTable: "Pedidos",
                        principalColumn: "idPedidos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealizarPedido_idCliente",
                table: "RealizarPedido",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_RealizarPedido_idPedidos",
                table: "RealizarPedido",
                column: "idPedidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealizarPedido");
        }
    }
}
