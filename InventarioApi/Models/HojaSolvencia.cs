namespace InventarioApi.Models;

public class HojaSolvencia
{
    public int Id { get; set; }

    // Datos de la solvencia
    public string SolvenciaNo { get; set; }
    public DateTime FechaSolvencia { get; set; }
    public string Observaciones { get; set; }

    // Relación con hoja
    public int HojaResponsabilidadId { get; set; }
    public HojaResponsabilidad HojaResponsabilidad { get; set; }

    // Datos de la hoja
    public string HojaNo { get; set; }
    public DateTime FechaHoja { get; set; }

    // Datos concatenados
    public string Empleados { get; set; }   // "Juan Pérez - Contador, María López - Analista"
    public string Equipos { get; set; }     // "PC-001 Dell XPS, LAP-002 HP EliteBook"

    // Auditoría
    public DateTime FechaRegistro { get; set; } = DateTime.Now;
}
