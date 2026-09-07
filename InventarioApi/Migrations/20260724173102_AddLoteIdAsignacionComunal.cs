using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AddLoteIdAsignacionComunal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.AsignacionesComunales', 'LoteId') IS NULL
BEGIN
    ALTER TABLE [AsignacionesComunales] ADD [LoteId] uniqueidentifier NULL;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.AsignacionesComunales', 'LoteId') IS NOT NULL
BEGIN
    ALTER TABLE [AsignacionesComunales] DROP COLUMN [LoteId];
END");
        }
    }
}
