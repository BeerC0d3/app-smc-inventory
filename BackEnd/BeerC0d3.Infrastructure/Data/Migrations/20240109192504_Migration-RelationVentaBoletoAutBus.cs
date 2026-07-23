using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class MigrationRelationVentaBoletoAutBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VentaBoletoAutobus_EstatusId",
                schema: "Comite",
                table: "VentaBoletoAutobus",
                column: "EstatusId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaBoletoAutobus_PeriodoId",
                schema: "Comite",
                table: "VentaBoletoAutobus",
                column: "PeriodoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaBoletoAutobus_CatalogoDetalle_EstatusId",
                schema: "Comite",
                table: "VentaBoletoAutobus",
                column: "EstatusId",
                principalSchema: "Sistema",
                principalTable: "CatalogoDetalle",
                principalColumn: "Id"
               );

            migrationBuilder.AddForeignKey(
                name: "FK_VentaBoletoAutobus_Periodo_PeriodoId",
                schema: "Comite",
                table: "VentaBoletoAutobus",
                column: "PeriodoId",
                principalSchema: "Comite",
                principalTable: "Periodo",
                principalColumn: "Id"
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaBoletoAutobus_CatalogoDetalle_EstatusId",
                schema: "Comite",
                table: "VentaBoletoAutobus");

            migrationBuilder.DropForeignKey(
                name: "FK_VentaBoletoAutobus_Periodo_PeriodoId",
                schema: "Comite",
                table: "VentaBoletoAutobus");

            migrationBuilder.DropIndex(
                name: "IX_VentaBoletoAutobus_EstatusId",
                schema: "Comite",
                table: "VentaBoletoAutobus");

            migrationBuilder.DropIndex(
                name: "IX_VentaBoletoAutobus_PeriodoId",
                schema: "Comite",
                table: "VentaBoletoAutobus");
        }
    }
}
