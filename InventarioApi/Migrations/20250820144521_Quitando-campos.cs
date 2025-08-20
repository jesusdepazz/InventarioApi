using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Quitandocampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccesoriosEntregados",
                table: "HojaResponsabilidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccesoriosEntregados",
                table: "HojaResponsabilidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
