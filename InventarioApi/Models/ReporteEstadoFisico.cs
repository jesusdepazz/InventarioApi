using System;

namespace InventoryApi.Models
{
    public class ReporteEstadoFisico
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string? EstadoFisico { get; set; }
        public string? Observaciones { get; set; }
    }
}
