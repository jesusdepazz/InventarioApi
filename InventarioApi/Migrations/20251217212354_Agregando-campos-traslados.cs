using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Agregandocampostraslados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonaRecibe",
                table: "Traslados",
                newName: "PuestoRecibe");

            migrationBuilder.RenameColumn(
                name: "PersonaEntrega",
                table: "Traslados",
                newName: "PuestoEntrega");

            migrationBuilder.AddColumn<string>(
                name: "CodigoEntrega",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodigoRecibe",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartamentoEntrega",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DepartamentoRecibe",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreEntrega",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NombreRecibe",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoEntrega",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "CodigoRecibe",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "DepartamentoEntrega",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "DepartamentoRecibe",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "NombreEntrega",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "NombreRecibe",
                table: "Traslados");

            migrationBuilder.RenameColumn(
                name: "PuestoRecibe",
                table: "Traslados",
                newName: "PersonaRecibe");

            migrationBuilder.RenameColumn(
                name: "PuestoEntrega",
                table: "Traslados",
                newName: "PersonaEntrega");
        }
    }
}
