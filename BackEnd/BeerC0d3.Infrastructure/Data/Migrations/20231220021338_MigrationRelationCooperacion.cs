using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class MigrationRelationCooperacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cooperacion_PeriodoId",
                schema: "Comite",
                table: "Cooperacion",
                column: "PeriodoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cooperacion_PersonaId",
                schema: "Comite",
                table: "Cooperacion",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperacion_Periodo_PeriodoId",
                schema: "Comite",
                table: "Cooperacion",
                column: "PeriodoId",
                principalSchema: "Comite",
                principalTable: "Periodo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cooperacion_Persona_PersonaId",
                schema: "Comite",
                table: "Cooperacion",
                column: "PersonaId",
                principalSchema: "Comite",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooperacion_Periodo_PeriodoId",
                schema: "Comite",
                table: "Cooperacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Cooperacion_Persona_PersonaId",
                schema: "Comite",
                table: "Cooperacion");

            migrationBuilder.DropIndex(
                name: "IX_Cooperacion_PeriodoId",
                schema: "Comite",
                table: "Cooperacion");

            migrationBuilder.DropIndex(
                name: "IX_Cooperacion_PersonaId",
                schema: "Comite",
                table: "Cooperacion");
        }
    }
}
