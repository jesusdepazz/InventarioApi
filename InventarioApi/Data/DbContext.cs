using InventarioApi.Models;
using Inventory.Models;
using InventoryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<EmpleadoInfo> EmpleadosInfo { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)     
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpleadoInfo>(entity =>
            {
                entity.ToTable("Empleado");
                entity.HasKey(e => e.Empleado);
            });
        }
    }
}
