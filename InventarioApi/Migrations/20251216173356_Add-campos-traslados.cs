using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Addcampostraslados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescripcionEquipo",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "Traslados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "TrasladoRetornos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "TrasladoRetornos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Serie",
                table: "TrasladoRetornos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionEquipo",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "Serie",
                table: "Traslados");

            migrationBuilder.DropColumn(
                name: "Marca",
                table: "TrasladoRetornos");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "TrasladoRetornos");

            migrationBuilder.DropColumn(
                name: "Serie",
                table: "TrasladoRetornos");
        }
    }
}
