using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class HojaResponsabilidadMovil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Accesorios",
                table: "HojasResponsabilidad",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Agregar columna TipoHoja solo si no existe (evita errores si ya está en la BD)
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojasResponsabilidad', 'TipoHoja') IS NULL
BEGIN
    ALTER TABLE [HojasResponsabilidad] ADD [TipoHoja] nvarchar(max) NOT NULL DEFAULT('');
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojaEquipos', 'Extension') IS NULL
BEGIN
    ALTER TABLE [HojaEquipos] ADD [Extension] nvarchar(max) NULL;
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojaEquipos', 'Imei') IS NULL
BEGIN
    ALTER TABLE [HojaEquipos] ADD [Imei] nvarchar(max) NULL;
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojaEquipos', 'NumeroAsignado') IS NULL
BEGIN
    ALTER TABLE [HojaEquipos] ADD [NumeroAsignado] nvarchar(max) NULL;
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.Equipos', 'EquipoTipo') IS NULL
BEGIN
    ALTER TABLE [Equipos] ADD [EquipoTipo] nvarchar(max) NULL;
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.Equipos', 'Imei') IS NULL
BEGIN
    ALTER TABLE [Equipos] ADD [Imei] nvarchar(max) NULL;
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.Equipos', 'NumeroAsignado') IS NULL
BEGIN
    ALTER TABLE [Equipos] ADD [NumeroAsignado] nvarchar(max) NULL;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar columna solo si existe
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojasResponsabilidad', 'TipoHoja') IS NOT NULL
BEGIN
    ALTER TABLE [HojasResponsabilidad] DROP COLUMN [TipoHoja];
END");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "HojaEquipos");

            migrationBuilder.DropColumn(
                name: "Imei",
                table: "HojaEquipos");

            migrationBuilder.DropColumn(
                name: "NumeroAsignado",
                table: "HojaEquipos");

            migrationBuilder.DropColumn(
                name: "EquipoTipo",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "Imei",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "NumeroAsignado",
                table: "Equipos");

            migrationBuilder.AlterColumn<string>(
                name: "Accesorios",
                table: "HojasResponsabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
