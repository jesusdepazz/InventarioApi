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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<HojaSolvencia> Solvencias { get; set; }
        public DbSet<HojaResponsabilidad> HojasResponsabilidad { get; set; }
        public DbSet<HojaEmpleado> HojaEmpleados { get; set; }
        public DbSet<HojaEquipo> HojaEquipos { get; set; }
        public DbSet<Traslado> Traslados { get; set; }
        public DbSet<Suministro> Suministros { get; set; }
        public DbSet<InventarioSuministro> InventarioSuministros { get; set; }
        public DbSet<MovimientoSuministro> MovimientoSuministros { get; set; }
        public DbSet<BajaActivo> BajaActivos { get; set; }
        public DbSet<TrasladoRetorno> TrasladoRetornos { get; set; }

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

            modelBuilder.Entity<HojaSolvencia>()
            .HasOne(s => s.HojaResponsabilidad)
            .WithMany(h => h.Solvencias)
            .HasForeignKey(s => s.HojaResponsabilidadId);

            modelBuilder.Entity<MovimientoSuministro>()
                .HasOne(m => m.UbicacionOrigen)
                .WithMany(u => u.MovimientosOrigen)
                .HasForeignKey(m => m.UbicacionOrigenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MovimientoSuministro>()
                .HasOne(m => m.UbicacionDestino)
                .WithMany(u => u.MovimientosDestino)
                .HasForeignKey(m => m.UbicacionDestinoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
