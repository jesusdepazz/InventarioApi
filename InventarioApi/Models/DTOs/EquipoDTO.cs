public class EquipoDTO
{
    public string OrderCompra { get; set; }
    public string Factura { get; set; }
    public string Proveedor { get; set; }
    public string Tipo { get; set; }
    public string Codificacion { get; set; }
    public string Estado { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string Imei { get; set; }
    public string? NumeroAsignado { get; set; }
    public string? Extension { get; set; }
    public string Especificaciones { get; set; }
    public string Accesorios { get; set; }
    public string Ubicacion { get; set; }
    public DateTime FechaIngreso { get; set; }
    public IFormFile? Imagen { get; set; }
}
