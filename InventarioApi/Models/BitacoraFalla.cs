using System;

namespace InventoryApi.Models
{
    public class BitacoraFalla
    {
        public int Id { get; set; }
        public int EquipoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string? Descripcion { get; set; }
        public string? AccionesTomadas { get; set; }
    }
}
