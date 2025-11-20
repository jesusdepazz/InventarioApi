namespace InventarioApi.Models.Suministros
{
    public class SalidaSuministro
    {
        public int Id { get; set; }

        public int SuministroId { get; set; }
        public Suministro Suministro { get; set; }

        public int CantidadProducto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
