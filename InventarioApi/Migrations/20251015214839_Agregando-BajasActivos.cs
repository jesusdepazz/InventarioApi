using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoBajasActivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BajaActivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaBaja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodificacionEquipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoBaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetallesBaja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionActual = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionDestino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BajaActivos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BajaActivos");
        }
    }
}
