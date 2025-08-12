using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        //datos generales
        public string RegistroDeprec {  get; set; }
        public string OrderCompra {  get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;

        //datos de usuario
        public string HojaNo {  get; set; }
        public DateTime FechaActualizacion {  get; set; } = DateTime.Now;

        //datos de equipos

        [Required]
        public string Codificacion { get; set; }
        public string TipoEquipo {  get; set; }

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
        public string Estado { get; set; }
        public string Tipo { get; set; }
        public string ResponsableAnterior { get; set; }
        public string? ImagenRuta { get; set; }
        public string Ubicacion { get; set; }

        //informacion de toma de inventario
        public string RevisadoTomaFisica { get; set; }
        public DateTime FechaToma { get; set; } = DateTime.Now;
        public string EstadoSticker { get; set; }
        public string AsignadoHojaResponsabilidad { get; set; }
        public string Comentarios {  get; set; }
        public string Observaciones { get; set; }

    }
}
