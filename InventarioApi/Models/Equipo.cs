using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        //datos de compra
        public string OrderCompra {  get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }

        //datos de equipos
        public string Tipo { get; set; }

        [Required]
        public string Codificacion { get; set; }
        public string Estado { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Imei { get; set; }
        public string? NumeroAsignado { get; set; }
        public string? Extension { get; set; }
        public string Especificaciones { get; set; }
        public string Accesorios { get; set; }
        public string Ubicacion { get; set; }
        public string? ImagenRuta { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
    }
}
