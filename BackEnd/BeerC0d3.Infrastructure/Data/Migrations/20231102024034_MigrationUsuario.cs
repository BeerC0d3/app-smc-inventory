using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerC0d3.Infrastructure.Data.Migrations
{
    public partial class MigrationUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                schema: "Seguridad",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CodigoActivacion",
                schema: "Seguridad",
                table: "Usuario",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmado",
                schema: "Seguridad",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActivacion",
                schema: "Seguridad",
                table: "Usuario",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                schema: "Seguridad",
                table: "Usuario",
                type: "datetime",
                nullable: false
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                schema: "Seguridad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "CodigoActivacion",
                schema: "Seguridad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "EmailConfirmado",
                schema: "Seguridad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FechaActivacion",
                schema: "Seguridad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                schema: "Seguridad",
                table: "Usuario");
        }
    }
}
