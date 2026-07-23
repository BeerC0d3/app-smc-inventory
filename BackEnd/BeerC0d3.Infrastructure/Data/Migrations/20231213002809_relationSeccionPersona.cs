using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class relationSeccionPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Persona_seccionId",
                schema: "Comite",
                table: "Persona",
                column: "seccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Seccion_seccionId",
                schema: "Comite",
                table: "Persona",
                column: "seccionId",
                principalSchema: "Comite",
                principalTable: "Seccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Seccion_seccionId",
                schema: "Comite",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_seccionId",
                schema: "Comite",
                table: "Persona");
        }
    }
}
