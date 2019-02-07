using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaParcial.Data.Migrations
{
    public partial class EstablecerEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstableserEntrega",
                columns: table => new
                {
                    idEsEntrega = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idEntrega = table.Column<int>(nullable: false),
                    idPedidos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstableserEntrega", x => x.idEsEntrega);
                    table.ForeignKey(
                        name: "FK_EstableserEntrega_Entrega_idEntrega",
                        column: x => x.idEntrega,
                        principalTable: "Entrega",
                        principalColumn: "idEntrega",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstableserEntrega_Pedidos_idPedidos",
                        column: x => x.idPedidos,
                        principalTable: "Pedidos",
                        principalColumn: "idPedidos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstableserEntrega_idEntrega",
                table: "EstableserEntrega",
                column: "idEntrega");

            migrationBuilder.CreateIndex(
                name: "IX_EstableserEntrega_idPedidos",
                table: "EstableserEntrega",
                column: "idPedidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstableserEntrega");
        }
    }
}
