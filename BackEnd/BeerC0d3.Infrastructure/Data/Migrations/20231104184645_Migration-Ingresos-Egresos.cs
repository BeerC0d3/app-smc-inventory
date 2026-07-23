using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class MigrationIngresosEgresos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Egresos",
                schema: "Comite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodoId = table.Column<int>(type: "int", nullable: false),
                    ConcentoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Egresos_CatalogoDetalle_ConcentoId",
                        column: x => x.ConcentoId,
                        principalSchema: "Sistema",
                        principalTable: "CatalogoDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Egresos_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalSchema: "Comite",
                        principalTable: "Periodo",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                schema: "Comite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodoId = table.Column<int>(type: "int", nullable: false),
                    ConcentoId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    UsuarioModificacion = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_CatalogoDetalle_ConcentoId",
                        column: x => x.ConcentoId,
                        principalSchema: "Sistema",
                        principalTable: "CatalogoDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingresos_Periodo_PeriodoId",
                        column: x => x.PeriodoId,
                        principalSchema: "Comite",
                        principalTable: "Periodo",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateIndex(
                name: "IX_Egresos_ConcentoId",
                schema: "Comite",
                table: "Egresos",
                column: "ConcentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Egresos_PeriodoId",
                schema: "Comite",
                table: "Egresos",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_ConcentoId",
                schema: "Comite",
                table: "Ingresos",
                column: "ConcentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_PeriodoId",
                schema: "Comite",
                table: "Ingresos",
                column: "PeriodoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Egresos",
                schema: "Comite");

            migrationBuilder.DropTable(
                name: "Ingresos",
                schema: "Comite");
        }
    }
}
