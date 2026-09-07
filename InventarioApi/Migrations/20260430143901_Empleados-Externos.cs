using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class EmpleadosExternos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF OBJECT_ID(N'dbo.EmpleadosExternos', N'U') IS NULL
BEGIN
    CREATE TABLE [EmpleadosExternos] (
        [Id] int NOT NULL IDENTITY,
        [CodigoEmpleado] nvarchar(20) NOT NULL,
        [Nombre] nvarchar(150) NOT NULL,
        [Puesto] nvarchar(100) NOT NULL,
        [Documento] nvarchar(30) NOT NULL,
        [Telefono] nvarchar(20) NULL,
        [FechaRegistro] datetime2 NOT NULL,
        [Activo] bit NOT NULL,
        CONSTRAINT [PK_EmpleadosExternos] PRIMARY KEY ([Id])
    );
END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF OBJECT_ID(N'dbo.EmpleadosExternos', N'U') IS NOT NULL
BEGIN
    DROP TABLE [EmpleadosExternos];
END");
        }
    }
}
