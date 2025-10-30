using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Updatepruebas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UbivacionRetorno",
                table: "TrasladoRetornos",
                newName: "UbicacionRetorno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UbicacionRetorno",
                table: "TrasladoRetornos",
                newName: "UbivacionRetorno");
        }
    }
}
