using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddobersvacionesHojaResp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojaEquipos', 'Observaciones') IS NULL
BEGIN
    ALTER TABLE [HojaEquipos] ADD [Observaciones] nvarchar(max) NULL;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojaEquipos', 'Observaciones') IS NOT NULL
BEGIN
    ALTER TABLE [HojaEquipos] DROP COLUMN [Observaciones];
END");
        }
    }
}
