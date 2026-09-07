using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSuministrosExternos_AddColorAndNewModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaSuministros_Suministros_SuministroId",
                table: "EntradaSuministros");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaSuministros_Suministros_SuministroId",
                table: "SalidaSuministros");

            migrationBuilder.DropTable(
                name: "EmpleadosExternos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suministros",
                table: "Suministros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalidaSuministros",
                table: "SalidaSuministros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradaSuministros",
                table: "EntradaSuministros");

            migrationBuilder.RenameTable(
                name: "Suministros",
                newName: "Suministro");

            migrationBuilder.RenameTable(
                name: "SalidaSuministros",
                newName: "SalidaSuministro");

            migrationBuilder.RenameTable(
                name: "EntradaSuministros",
                newName: "EntradaSuministro");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaSuministros_SuministroId",
                table: "SalidaSuministro",
                newName: "IX_SalidaSuministro_SuministroId");

            migrationBuilder.RenameIndex(
                name: "IX_EntradaSuministros_SuministroId",
                table: "EntradaSuministro",
                newName: "IX_EntradaSuministro_SuministroId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Equipos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroBaja",
                table: "BajaActivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suministro",
                table: "Suministro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalidaSuministro",
                table: "SalidaSuministro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradaSuministro",
                table: "EntradaSuministro",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Alertas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Leida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alertas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BitacoraFallas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccionesTomadas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraFallas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoEquipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoEquipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaltantesSobrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    CantidadSistema = table.Column<int>(type: "int", nullable: false),
                    CantidadContada = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaltantesSobrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolizasSeguro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    NumeroPoliza = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cobertura = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolizasSeguro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportesEstadoFisico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoFisico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportesEstadoFisico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TomasFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TomasFisicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TomaFisicaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TomaFisicaId = table.Column<int>(type: "int", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    CantidadContada = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TomaFisicaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TomaFisicaItems_TomasFisicas_TomaFisicaId",
                        column: x => x.TomaFisicaId,
                        principalTable: "TomasFisicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TomaFisicaItems_TomaFisicaId",
                table: "TomaFisicaItems",
                column: "TomaFisicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaSuministro_Suministro_SuministroId",
                table: "EntradaSuministro",
                column: "SuministroId",
                principalTable: "Suministro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaSuministro_Suministro_SuministroId",
                table: "SalidaSuministro",
                column: "SuministroId",
                principalTable: "Suministro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaSuministro_Suministro_SuministroId",
                table: "EntradaSuministro");

            migrationBuilder.DropForeignKey(
                name: "FK_SalidaSuministro_Suministro_SuministroId",
                table: "SalidaSuministro");

            migrationBuilder.DropTable(
                name: "Alertas");

            migrationBuilder.DropTable(
                name: "BitacoraFallas");

            migrationBuilder.DropTable(
                name: "CatalogoEquipos");

            migrationBuilder.DropTable(
                name: "FaltantesSobrantes");

            migrationBuilder.DropTable(
                name: "PolizasSeguro");

            migrationBuilder.DropTable(
                name: "ReportesEstadoFisico");

            migrationBuilder.DropTable(
                name: "TomaFisicaItems");

            migrationBuilder.DropTable(
                name: "TomasFisicas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suministro",
                table: "Suministro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SalidaSuministro",
                table: "SalidaSuministro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradaSuministro",
                table: "EntradaSuministro");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "NumeroBaja",
                table: "BajaActivos");

            migrationBuilder.RenameTable(
                name: "Suministro",
                newName: "Suministros");

            migrationBuilder.RenameTable(
                name: "SalidaSuministro",
                newName: "SalidaSuministros");

            migrationBuilder.RenameTable(
                name: "EntradaSuministro",
                newName: "EntradaSuministros");

            migrationBuilder.RenameIndex(
                name: "IX_SalidaSuministro_SuministroId",
                table: "SalidaSuministros",
                newName: "IX_SalidaSuministros_SuministroId");

            migrationBuilder.RenameIndex(
                name: "IX_EntradaSuministro_SuministroId",
                table: "EntradaSuministros",
                newName: "IX_EntradaSuministros_SuministroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suministros",
                table: "Suministros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SalidaSuministros",
                table: "SalidaSuministros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradaSuministros",
                table: "EntradaSuministros",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmpleadosExternos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CodigoEmpleado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Proyecto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Puesto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadosExternos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaSuministros_Suministros_SuministroId",
                table: "EntradaSuministros",
                column: "SuministroId",
                principalTable: "Suministros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalidaSuministros_Suministros_SuministroId",
                table: "SalidaSuministros",
                column: "SuministroId",
                principalTable: "Suministros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
