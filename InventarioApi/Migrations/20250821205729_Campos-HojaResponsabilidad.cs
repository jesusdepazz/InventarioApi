using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioApi.Migrations
{
    /// <inheritdoc />
    public partial class CamposHojaResponsabilidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "HojasResponsabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FechaSolvencia",
                table: "HojasResponsabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "HojasResponsabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SolvenciNo",
                table: "HojasResponsabilidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "HojasResponsabilidad");

            migrationBuilder.DropColumn(
                name: "FechaSolvencia",
                table: "HojasResponsabilidad");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "HojasResponsabilidad");

            migrationBuilder.DropColumn(
                name: "SolvenciNo",
                table: "HojasResponsabilidad");
        }
    }
}
