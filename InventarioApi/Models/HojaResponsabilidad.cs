using InventoryApi.Models;

namespace InventarioApi.Models
{
    public class HojaResponsabilidad
    {
        public int Id { get; set; }
        public string? HojaNo { get; set; }
        public string JefeInmediato { get; set; }
        public string MotivoActualizacion { get; set; }
        public string AccesoriosEntregados { get; set; }
        public string Comentarios { get; set; }
        public List<string> CodigosEmpleados { get; set; } = new();
        public List<string> CodigosEquipos { get; set; } = new();

    }
}
