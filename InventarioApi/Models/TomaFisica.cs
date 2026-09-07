using System;
using System.Collections.Generic;

namespace InventoryApi.Models
{
    public class TomaFisica
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public string? Usuario { get; set; }
        public string? Descripcion { get; set; }
        public List<TomaFisicaItem>? Items { get; set; }
    }
}
