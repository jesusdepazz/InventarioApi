using System;

namespace InventoryApi.Models
{
    public class PolizaSeguro
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public string? NumeroPoliza { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string? Cobertura { get; set; }
    }
}
