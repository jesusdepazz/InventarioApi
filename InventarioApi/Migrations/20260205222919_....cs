using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            // Crear tabla Traslados solo si no existe (evita error si ya existe en la BD)
            migrationBuilder.Sql(@"IF OBJECT_ID(N'dbo.Traslados', N'U') IS NULL
BEGIN
    CREATE TABLE [Traslados] (
        [Id] int NOT NULL IDENTITY,
        [No] nvarchar(max) NOT NULL,
        [FechaEmision] datetime2 NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [Motivo] nvarchar(max) NOT NULL,
        [Observaciones] nvarchar(max) NOT NULL,
        [UbicacionDesde] nvarchar(max) NOT NULL,
        [UbicacionHasta] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Traslados] PRIMARY KEY ([Id])
    );
END");


            migrationBuilder.Sql(@"IF OBJECT_ID(N'dbo.TrasladoEmpleadoEntregas', N'U') IS NULL
BEGIN
    CREATE TABLE [TrasladoEmpleadoEntregas] (
        [Id] int NOT NULL IDENTITY,
        [TrasladoId] int NOT NULL,
        [Codigo] nvarchar(max) NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Puesto] nvarchar(max) NOT NULL,
        [Departamento] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TrasladoEmpleadoEntregas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrasladoEmpleadoEntregas_Traslados_TrasladoId] FOREIGN KEY ([TrasladoId]) REFERENCES [Traslados] ([Id]) ON DELETE CASCADE
    );
END");

            migrationBuilder.Sql(@"IF OBJECT_ID(N'dbo.TrasladoEmpleadoRecibes', N'U') IS NULL
BEGIN
    CREATE TABLE [TrasladoEmpleadoRecibes] (
        [Id] int NOT NULL IDENTITY,
        [TrasladoId] int NOT NULL,
        [Codigo] nvarchar(max) NOT NULL,
        [Nombre] nvarchar(max) NOT NULL,
        [Puesto] nvarchar(max) NOT NULL,
        [Departamento] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TrasladoEmpleadoRecibes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrasladoEmpleadoRecibes_Traslados_TrasladoId] FOREIGN KEY ([TrasladoId]) REFERENCES [Traslados] ([Id]) ON DELETE CASCADE
    );
END");

            migrationBuilder.Sql(@"IF OBJECT_ID(N'dbo.TrasladoEquipos', N'U') IS NULL
BEGIN
    CREATE TABLE [TrasladoEquipos] (
        [Id] int NOT NULL IDENTITY,
        [TrasladoId] int NOT NULL,
        [Equipo] nvarchar(max) NOT NULL,
        [DescripcionEquipo] nvarchar(max) NOT NULL,
        [Marca] nvarchar(max) NOT NULL,
        [Modelo] nvarchar(max) NOT NULL,
        [Serie] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_TrasladoEquipos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_TrasladoEquipos_Traslados_TrasladoId] FOREIGN KEY ([TrasladoId]) REFERENCES [Traslados] ([Id]) ON DELETE CASCADE
    );
END");

            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_TrasladoEmpleadoEntregas_TrasladoId' AND object_id = OBJECT_ID('dbo.TrasladoEmpleadoEntregas'))
BEGIN
    CREATE UNIQUE INDEX [IX_TrasladoEmpleadoEntregas_TrasladoId] ON [TrasladoEmpleadoEntregas] ([TrasladoId]);
END");

            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_TrasladoEmpleadoRecibes_TrasladoId' AND object_id = OBJECT_ID('dbo.TrasladoEmpleadoRecibes'))
BEGIN
    CREATE UNIQUE INDEX [IX_TrasladoEmpleadoRecibes_TrasladoId] ON [TrasladoEmpleadoRecibes] ([TrasladoId]);
END");

            migrationBuilder.Sql(@"IF NOT EXISTS (SELECT name FROM sys.indexes WHERE name = 'IX_TrasladoEquipos_TrasladoId' AND object_id = OBJECT_ID('dbo.TrasladoEquipos'))
BEGIN
    CREATE INDEX [IX_TrasladoEquipos_TrasladoId] ON [TrasladoEquipos] ([TrasladoId]);
END");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrasladoEmpleadoEntregas");

            migrationBuilder.DropTable(
                name: "TrasladoEmpleadoRecibes");

            migrationBuilder.DropTable(
                name: "TrasladoEquipos");

            migrationBuilder.DropTable(
                name: "Traslados");
        }
    }
}
