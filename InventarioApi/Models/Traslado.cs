namespace InventarioApi.Models;

public class Traslado
{
    public int Id { get; set; }
    public string No {  get; set; }
    public DateTime FechaEmision { get; set; }
    public string PersonaEntrega { get; set; }
    public string PersonaRecibe { get; set; }
    public string Equipo { get; set; }
    public string DescripcionEquipo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string Motivo { get; set; }
    public string UbicacionDesde { get; set; }
    public string UbicacionHasta {  get; set; }
    public string Status {  get; set; }
    public string Observaciones { get; set; }

}
