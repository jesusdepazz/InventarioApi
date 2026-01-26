using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddcambiotrasladosRetorno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrasladoRetornos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaPase = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MotivoSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionRetorno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRetorno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaRetira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreProveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrasladoRetornos", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "TrasladoRetornEquipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrasladoRetornoId = table.Column<int>(type: "int", nullable: false),
                    Equipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DescripcionEquipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrasladoRetornEquipos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrasladoRetornEquipos_TrasladoRetornos_TrasladoRetornoId",
                        column: x => x.TrasladoRetornoId,
                        principalTable: "TrasladoRetornos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrasladoRetornoEmpleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrasladoRetornoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Puesto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrasladoRetornoEmpleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrasladoRetornoEmpleados_TrasladoRetornos_TrasladoRetornoId",
                        column: x => x.TrasladoRetornoId,
                        principalTable: "TrasladoRetornos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrasladoRetornEquipos_TrasladoRetornoId",
                table: "TrasladoRetornEquipos",
                column: "TrasladoRetornoId");

            migrationBuilder.CreateIndex(
                name: "IX_TrasladoRetornoEmpleados_TrasladoRetornoId",
                table: "TrasladoRetornoEmpleados",
                column: "TrasladoRetornoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "TrasladoRetornEquipos");

            migrationBuilder.DropTable(
                name: "TrasladoRetornoEmpleados");

            migrationBuilder.DropTable(
                name: "TrasladoRetornos");
        }
    }
}
