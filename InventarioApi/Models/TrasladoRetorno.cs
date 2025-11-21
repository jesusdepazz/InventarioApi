namespace InventarioApi.Models;

public class TrasladoRetorno
{
    public int Id { get; set; }
    public string No {  get; set; }
    public DateTime FechaPase { get; set; }
    public string Solicitante { get; set; }
    public string Equipo { get; set; }
    public string DescripcionEquipo { get; set; }
    public string MotivoSalida { get; set; }
    public string UbicacionRetorno { get; set; }
    public string FechaRetorno { get; set; }
    public string Status { get; set; }
    public string RazonNoLiquidada { get; set; }

}
