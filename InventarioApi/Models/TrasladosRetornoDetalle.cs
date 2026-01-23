public class TrasladoRetornoDetalle
{
    public int Id { get; set; }
    public int TrasladoRetornoId { get; set; }

    public string Equipo { get; set; }
    public string DescripcionEquipo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string UbicacionRetorno { get; set; }

    public TrasladoRetorno TrasladoRetorno { get; set; }
}
