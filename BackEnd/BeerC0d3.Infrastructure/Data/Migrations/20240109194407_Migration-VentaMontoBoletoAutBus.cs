using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class MigrationVentaMontoBoletoAutBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VentaMontoBoletoAutobus",
                schema: "Comite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaBoletoAutId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaMontoBoletoAutobus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaMontoBoletoAutobus_VentaBoletoAutobus_VentaBoletoAutId",
                        column: x => x.VentaBoletoAutId,
                        principalSchema: "Comite",
                        principalTable: "VentaBoletoAutobus",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentaMontoBoletoAutobus_VentaBoletoAutId",
                schema: "Comite",
                table: "VentaMontoBoletoAutobus",
                column: "VentaBoletoAutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaMontoBoletoAutobus",
                schema: "Comite");
        }
    }
}
