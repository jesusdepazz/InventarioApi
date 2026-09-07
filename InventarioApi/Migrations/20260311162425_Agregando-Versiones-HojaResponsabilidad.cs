using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoVersionesHojaResponsabilidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojasResponsabilidad', 'Version') IS NULL
BEGIN
    ALTER TABLE [HojasResponsabilidad] ADD [Version] int NOT NULL DEFAULT(0);
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF COL_LENGTH('dbo.HojasResponsabilidad', 'Version') IS NOT NULL
BEGIN
    ALTER TABLE [HojasResponsabilidad] DROP COLUMN [Version];
END");
        }
    }
}
