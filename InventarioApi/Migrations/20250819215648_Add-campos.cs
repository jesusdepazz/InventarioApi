using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Addcampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Equipo",
                table: "HojaResponsabilidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaEquipo",
                table: "HojaResponsabilidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipo",
                table: "HojaResponsabilidades");

            migrationBuilder.DropColumn(
                name: "FechaEquipo",
                table: "HojaResponsabilidades");
        }
    }
}
