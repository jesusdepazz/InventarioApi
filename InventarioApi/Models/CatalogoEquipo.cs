using System;

namespace InventoryApi.Models
{
    public class CatalogoEquipo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? TipoEquipo { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
    }
}
