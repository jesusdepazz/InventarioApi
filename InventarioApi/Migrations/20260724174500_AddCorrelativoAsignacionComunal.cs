using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddCorrelativoAsignacionComunal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.AsignacionesComunales', 'Correlativo') IS NULL
BEGIN
    ALTER TABLE [AsignacionesComunales] ADD [Correlativo] nvarchar(max) NULL;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.AsignacionesComunales', 'Correlativo') IS NOT NULL
BEGIN
    ALTER TABLE [AsignacionesComunales] DROP COLUMN [Correlativo];
END");
        }
    }
}
