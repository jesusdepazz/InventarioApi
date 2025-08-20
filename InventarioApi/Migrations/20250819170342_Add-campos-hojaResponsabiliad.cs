using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddcamposhojaResponsabiliad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "HojaResponsabilidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaActualizacion",
                table: "HojaResponsabilidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSolvencia",
                table: "HojaResponsabilidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "HojaResponsabilidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SolvenciaNo",
                table: "HojaResponsabilidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "HojaResponsabilidades");

            migrationBuilder.DropColumn(
                name: "FechaActualizacion",
                table: "HojaResponsabilidades");

            migrationBuilder.DropColumn(
                name: "FechaSolvencia",
                table: "HojaResponsabilidades");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "HojaResponsabilidades");

            migrationBuilder.DropColumn(
                name: "SolvenciaNo",
                table: "HojaResponsabilidades");
        }
    }
}
