using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Quitadocamposequipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsignadoHojaResponsabilidad",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "EstadoSticker",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "FechaToma",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "RevisadoTomaFisica",
                table: "Equipos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AsignadoHojaResponsabilidad",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoSticker",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaToma",
                table: "Equipos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevisadoTomaFisica",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
