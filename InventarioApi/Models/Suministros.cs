using Inventory.Models;

namespace InventarioApi.Models
{
    public class Suministro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;      
        public string? Descripcion { get; set; }
        public string UnidadMedida { get; set; } = "Unidad";    
        public int StockTotal { get; set; } = 0;                
        public bool Activo { get; set; } = true;

        public ICollection<InventarioSuministro>? Inventarios { get; set; }
        public ICollection<MovimientoSuministro>? Movimientos { get; set; }
    }

    public class InventarioSuministro
    {
        public int Id { get; set; }

        public int SuministroId { get; set; }
        public Suministro? Suministro { get; set; }

        public int UbicacionId { get; set; }
        public Ubicacion? Ubicacion { get; set; }
        public int Cantidad { get; set; } = 0;
    }

    public class MovimientoSuministro
    {
        public int Id { get; set; }

        public int SuministroId { get; set; }
        public Suministro? Suministro { get; set; }

        public string TipoMovimiento { get; set; } = string.Empty;

        public int? UbicacionOrigenId { get; set; }
        public Ubicacion? UbicacionOrigen { get; set; } 

        public int? UbicacionDestinoId { get; set; }
        public Ubicacion? UbicacionDestino { get; set; }

        public int Cantidad { get; set; }
        public DateTime FechaMovimiento { get; set; } = DateTime.UtcNow;
        public string? RealizadoPor { get; set; }
        public string? Observacion { get; set; }
    }


}
