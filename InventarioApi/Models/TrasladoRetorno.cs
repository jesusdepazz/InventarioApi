public class TrasladoRetorno
{
    public int Id { get; set; }
    public string No { get; set; }
    public DateTime FechaPase { get; set; }
    public string Solicitante { get; set; }
    public string MotivoSalida { get; set; }
    public DateTime? FechaRetorno { get; set; }
    public string Status { get; set; }
    public string RazonNoLiquidada { get; set; }

    public ICollection<TrasladoRetornoDetalle> Detalles { get; set; }
}
