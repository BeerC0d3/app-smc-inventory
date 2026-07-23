using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class RelationPersonaIdTableventaboleto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VentaBoletoAutobus_PersonaId",
                schema: "Comite",
                table: "VentaBoletoAutobus",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaBoletoAutobus_Persona_PersonaId",
                schema: "Comite",
                table: "VentaBoletoAutobus",
                column: "PersonaId",
                principalSchema: "Comite",
                principalTable: "Persona",
                principalColumn: "Id"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaBoletoAutobus_Persona_PersonaId",
                schema: "Comite",
                table: "VentaBoletoAutobus");

            migrationBuilder.DropIndex(
                name: "IX_VentaBoletoAutobus_PersonaId",
                schema: "Comite",
                table: "VentaBoletoAutobus");
        }
    }
}
