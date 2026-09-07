namespace InventoryApi.Models
{
    public class TomaFisicaItem
    {
        public int Id { get; set; }
        public int TomaFisicaId { get; set; }
        public int EquipoId { get; set; }
        public int CantidadContada { get; set; }
        public string? Observacion { get; set; }
    }
}
