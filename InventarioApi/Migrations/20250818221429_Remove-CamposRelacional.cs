using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCamposRelacional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigosEmpleados",
                table: "HojaResponsabilidades");

            migrationBuilder.DropColumn(
                name: "CodigosEquipos",
                table: "HojaResponsabilidades");
        }
    }
}
