namespace InventarioApi.Models;

public class Traslado
{
    public int Id { get; set; }
    public string No {  get; set; }
    public DateTime FechaEmision { get; set; }
    public string Solicitante { get; set; }
    public string DescripcionEquipo { get; set; }
    public string Motivo { get; set; }
    public string UbicacionDesde { get; set; }
    public string UbicacionHasta {  get; set; }
    public string Status {  get; set; }
    public DateTime? FechaLiquidacion { get; set; }
    public string Razon {  get; set; }

}
