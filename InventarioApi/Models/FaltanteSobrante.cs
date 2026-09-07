using System;

namespace InventoryApi.Models
{
    public class FaltanteSobrante
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public int CantidadSistema { get; set; }
        public int CantidadContada { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string? Tipo => CantidadContada < CantidadSistema ? "Faltante" : (CantidadContada > CantidadSistema ? "Sobrante" : "Igual");
    }
}
