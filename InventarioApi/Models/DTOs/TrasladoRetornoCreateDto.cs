public class TrasladoRetornoCreateDto
{
    public string No { get; set; }
    public DateTime FechaPase { get; set; }
    public string Solicitante { get; set; }
    public string MotivoSalida { get; set; }
    public DateTime? FechaRetorno { get; set; }
    public string Status { get; set; }
    public string RazonNoLiquidada { get; set; }

    public List<TrasladoRetornoDetalleDto> Equipos { get; set; }
}
