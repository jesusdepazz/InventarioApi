using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCampos_equipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "Equipos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HojaNo",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistroDeprec",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoEquipo",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "HojaNo",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "RegistroDeprec",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "TipoEquipo",
                table: "Equipos");
        }
    }
}
