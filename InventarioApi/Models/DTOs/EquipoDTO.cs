public class EquipoDTO
{
    public string RegistroDeprec {  get; set; }
    public string OrderCompra { get; set; }
    public string Factura { get; set; }
    public string Proveedor { get; set; }
    public DateTime FechaIngreso { get; set; }
    public string HojaNo {  get; set; }
    public DateTime FechaActualizacion { get; set; }
    public string Codificacion { get; set; }
    public string TipoEquipo { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string Imei { get; set; }
    public string? NumeroAsignado { get; set; }
    public string? Extension { get; set; }
    public string Tipo { get; set; }
    public string Estado { get; set; }
    public string Especificaciones { get; set; }
    public string Accesorios { get; set; }
    public string Ubicacion { get; set; }
    public IFormFile? Imagen { get; set; }

    //informacion de toma de inventario
    public string RevisadoTomaFisica { get; set; }
    public DateTime FechaToma { get; set; } = DateTime.Now;
    public string EstadoSticker { get; set; }
    public string AsignadoHojaResponsabilidad { get; set; }
    public string Comentarios { get; set; }
    public string Observaciones { get; set; }
}
