using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposSolvencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Solvencias",
                newName: "FechaSolvencia");

            migrationBuilder.AddColumn<string>(
                name: "CodificacionEquipo",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoEmpleado",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHoja",
                table: "Solvencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Solvencias",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HojaNo",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEmpleado",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Puesto",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UbicacionEquipo",
                table: "Solvencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodificacionEquipo",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "CodigoEmpleado",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "FechaHoja",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "HojaNo",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "NombreEmpleado",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "Puesto",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "Serie",
                table: "Solvencias");

            migrationBuilder.DropColumn(
                name: "UbicacionEquipo",
                table: "Solvencias");

            migrationBuilder.RenameColumn(
                name: "FechaSolvencia",
                table: "Solvencias",
                newName: "FechaCreacion");
        }
    }
}
