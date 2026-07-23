using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class MigrationVentaDetalleBoletoAutBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VentaDetalleBoletoAutobus",
                schema: "Comite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaBoletoAutId = table.Column<int>(type: "int", nullable: false),
                    BoletoAutId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaDetalleBoletoAutobus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaDetalleBoletoAutobus_BoletoAutobus_BoletoAutId",
                        column: x => x.BoletoAutId,
                        principalSchema: "Comite",
                        principalTable: "BoletoAutobus",
                        principalColumn: "Id"
                        );
                    table.ForeignKey(
                        name: "FK_VentaDetalleBoletoAutobus_VentaBoletoAutobus_VentaBoletoAutId",
                        column: x => x.VentaBoletoAutId,
                        principalSchema: "Comite",
                        principalTable: "VentaBoletoAutobus",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalleBoletoAutobus_BoletoAutId",
                schema: "Comite",
                table: "VentaDetalleBoletoAutobus",
                column: "BoletoAutId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaDetalleBoletoAutobus_VentaBoletoAutId",
                schema: "Comite",
                table: "VentaDetalleBoletoAutobus",
                column: "VentaBoletoAutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaDetalleBoletoAutobus",
                schema: "Comite");
        }
    }
}
