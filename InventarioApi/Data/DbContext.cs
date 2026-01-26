using InventarioApi.Models;
using InventarioApi.Models.Suministros;
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
        public DbSet<EntradaSuministro> EntradaSuministros { get; set; }
        public DbSet<SalidaSuministro> SalidaSuministros { get; set; }
        public DbSet<BajaActivo> BajaActivos { get; set; }
        public DbSet<TrasladoRetorno> TrasladoRetornos { get; set; }
        public DbSet<TrasladoRetornoEquipo> TrasladoRetornEquipos { get; set; }
        public DbSet<TrasladoRetornoEmpleado> TrasladoRetornoEmpleados { get; set; }
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

            modelBuilder.Entity<Suministro>()
                .HasMany(s => s.Entradas)
                .WithOne(e => e.Suministro)
                .HasForeignKey(e => e.SuministroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Suministro>()
                .HasMany(s => s.Salidas)
                .WithOne(sal => sal.Suministro)
                .HasForeignKey(sal => sal.SuministroId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrasladoRetorno>(entity =>
            {
                entity.HasKey(t => t.Id);

                entity.HasMany(t => t.Equipos)
                      .WithOne(d => d.TrasladoRetorno)
                      .HasForeignKey(d => d.TrasladoRetornoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<TrasladoRetornoEquipo>(entity =>
            {
                entity.HasKey(d => d.Id);

                entity.Property(d => d.Equipo)
                      .IsRequired()
                      .HasMaxLength(50);
            });

            modelBuilder.Entity<TrasladoRetornoEmpleado>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.EmpleadoId)
                      .IsRequired();

                entity.HasOne(e => e.TrasladoRetorno)
                      .WithOne(t => t.Empleado)
                      .HasForeignKey<TrasladoRetornoEmpleado>(e => e.TrasladoRetornoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}
