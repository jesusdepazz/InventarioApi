using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class ErrorcampoSolvenciaNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SolvenciNo",
                table: "HojasResponsabilidad",
                newName: "SolvenciaNo");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaSolvencia",
                table: "HojasResponsabilidad",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SolvenciaNo",
                table: "HojasResponsabilidad",
                newName: "SolvenciNo");

            migrationBuilder.AlterColumn<string>(
                name: "FechaSolvencia",
                table: "HojasResponsabilidad",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
