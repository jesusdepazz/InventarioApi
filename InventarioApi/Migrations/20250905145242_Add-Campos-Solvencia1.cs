using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposSolvencia1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "UbicacionEquipo",
                table: "Solvencias",
                newName: "Equipos");

            migrationBuilder.RenameColumn(
                name: "Serie",
                table: "Solvencias",
                newName: "Empleados");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Equipos",
                table: "Solvencias",
                newName: "UbicacionEquipo");

            migrationBuilder.RenameColumn(
                name: "Empleados",
                table: "Solvencias",
                newName: "Serie");

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
        }
    }
}
