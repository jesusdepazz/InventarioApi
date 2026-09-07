using System;

namespace InventoryApi.Models
{
    public class Alerta
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public string? Mensaje { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public bool Leida { get; set; }
    }
}
