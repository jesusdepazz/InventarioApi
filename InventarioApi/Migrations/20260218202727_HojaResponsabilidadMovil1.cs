using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class HojaResponsabilidadMovil1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojaEquipos', 'EquipoTipo') IS NULL
BEGIN
    ALTER TABLE [HojaEquipos] ADD [EquipoTipo] nvarchar(max) NOT NULL DEFAULT('');
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojaEquipos', 'EquipoTipo') IS NOT NULL
BEGIN
    ALTER TABLE [HojaEquipos] DROP COLUMN [EquipoTipo];
END");
        }
    }
}
