using InventarioApi.Models;
using Inventory.Models;
using InventoryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Data
{
    public class InventarioContext : DbContext
    {
        public InventarioContext(DbContextOptions<InventarioContext> options) : base(options) { }

        // Tablas existentes
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }
        public DbSet<EmpleadoInfo> EmpleadosInfo { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HojaResponsabilidad> HojasResponsabilidad { get; set; }
        public DbSet<HojaEmpleado> HojaEmpleados { get; set; }
        public DbSet<HojaEquipo> HojaEquipos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmpleadoInfo>(entity =>
            {
                entity.ToTable("Empleado");
                entity.HasKey(e => e.Empleado);
            });

            modelBuilder.Entity<HojaEmpleado>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.EmpleadoId).IsRequired();

                entity.HasOne(h => h.HojaResponsabilidad)
                      .WithMany(h => h.Empleados)
                      .HasForeignKey(h => h.HojaResponsabilidadId);
            });

            modelBuilder.Entity<HojaEquipo>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.Property(h => h.Codificacion).IsRequired();

                entity.HasOne(h => h.HojaResponsabilidad)
                      .WithMany(h => h.Equipos)
                      .HasForeignKey(h => h.HojaResponsabilidadId);
            });
        }
    }
}
