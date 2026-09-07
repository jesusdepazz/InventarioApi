using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEstadoTrasladosRetorno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.TrasladoRetornos', 'Estado') IS NULL
BEGIN
    ALTER TABLE [TrasladoRetornos] ADD [Estado] nvarchar(max) NOT NULL DEFAULT('');
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.TrasladoRetornos', 'Estado') IS NOT NULL
BEGIN
    ALTER TABLE [TrasladoRetornos] DROP COLUMN [Estado];
END");
        }
    }
}
