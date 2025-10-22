namespace InventarioApi.Models.DTOs;

public class CrearSuministroDto
{
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string UnidadMedida { get; set; } = "Unidad";
}

public class MovimientoDto
{
    public int SuministroId { get; set; }
    public string TipoMovimiento { get; set; } = string.Empty;
    public int? UbicacionOrigenId { get; set; }
    public int? UbicacionDestinoId { get; set; } 
    public int Cantidad { get; set; }
    public string? RealizadoPor { get; set; }
    public string? Observacion { get; set; }
}

