namespace InventarioApi.Models.DTOs
{
    public class EditarEquipoDTO
    {   
        public int Id { get; set; }
        public string? Codificacion { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Serie { get; set; }
        public string? Ubicacion { get; set; }
    }

}
