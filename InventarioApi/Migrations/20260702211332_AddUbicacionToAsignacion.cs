using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUbicacionToAsignacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.Asignaciones', 'Ubicacion') IS NULL
BEGIN
    ALTER TABLE [Asignaciones] ADD [Ubicacion] nvarchar(max) NULL;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.Asignaciones', 'Ubicacion') IS NOT NULL
BEGIN
    ALTER TABLE [Asignaciones] DROP COLUMN [Ubicacion];
END");
        }
    }
}
