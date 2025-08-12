using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class agregando_campo_equipos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponsableAnterior",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponsableAnterior",
                table: "Equipos");
        }
    }
}
