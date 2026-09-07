using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Solvencia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.Solvencias', 'JefeInmediato') IS NULL
BEGIN
    ALTER TABLE [Solvencias] ADD [JefeInmediato] nvarchar(max) NOT NULL DEFAULT('');
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.Solvencias', 'JefeInmediato') IS NOT NULL
BEGIN
    ALTER TABLE [Solvencias] DROP COLUMN [JefeInmediato];
END");
        }
    }
}
