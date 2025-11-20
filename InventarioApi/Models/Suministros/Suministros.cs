using Inventory.Models;

namespace InventarioApi.Models.Suministros
{
    public class Suministro
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string UbicacionProducto { get; set; }
        public string CantidadActual { get; set; }
        public DateTime DateTime { get; set; }
        public List<EntradaSuministro> Entradas { get; set; }
        public List<SalidaSuministro> Salidas { get; set; }

    }


}
