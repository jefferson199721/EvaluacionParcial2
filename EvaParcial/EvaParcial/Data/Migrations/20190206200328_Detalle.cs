using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvaParcial.Data.Migrations
{
    public partial class Detalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    idDetalle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    idCliente = table.Column<int>(nullable: false),
                    idDistribuidor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.idDetalle);
                    table.ForeignKey(
                        name: "FK_Detalle_Cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Distribuidores_idDistribuidor",
                        column: x => x.idDistribuidor,
                        principalTable: "Distribuidores",
                        principalColumn: "idDistribuidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_idCliente",
                table: "Detalle",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_idDistribuidor",
                table: "Detalle",
                column: "idDistribuidor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");
        }
    }
}
