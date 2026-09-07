using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class Agregandoexternos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojasResponsabilidad', 'Proyecto') IS NULL
BEGIN
    ALTER TABLE [HojasResponsabilidad] ADD [Proyecto] nvarchar(max) NULL;
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.EmpleadosExternos', 'Proyecto') IS NULL
BEGIN
    ALTER TABLE [EmpleadosExternos] ADD [Proyecto] nvarchar(150) NULL;
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojasResponsabilidad', 'Proyecto') IS NOT NULL
BEGIN
    ALTER TABLE [HojasResponsabilidad] DROP COLUMN [Proyecto];
END");

            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.EmpleadosExternos', 'Proyecto') IS NOT NULL
BEGIN
    ALTER TABLE [EmpleadosExternos] DROP COLUMN [Proyecto];
END");
        }
    }
}
