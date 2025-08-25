using System.Text.Json.Serialization;

public class HojaResponsabilidad
{
    public int Id { get; set; }
    public string HojaNo { get; set; }
    public string Motivo { get; set; }
    public string Comentarios { get; set; }
    public string Estado { get; set; }
    public string SolvenciaNo { get; set; }
    public DateTime FechaSolvencia { get; set; } = DateTime.Now;
    public string Observaciones { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public List<HojaEmpleado> Empleados { get; set; } = new();
    public List<HojaEquipo> Equipos { get; set; } = new();
}

public class HojaEmpleado
{
    public int Id { get; set; }
    public int HojaResponsabilidadId { get; set; }
    public string EmpleadoId { get; set; } 
    public string Nombre { get; set; }
    public string Puesto { get; set; }
    public string Departamento { get; set; }

    [JsonIgnore]
    public HojaResponsabilidad HojaResponsabilidad { get; set; }
}

public class HojaEquipo
{
    public int Id { get; set; }
    public int HojaResponsabilidadId { get; set; }
    public string Codificacion { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string Tipo { get; set; }
    public string TipoEquipo { get; set; }
    public string Estado { get; set; }
    public string Ubicacion { get; set; }

    [JsonIgnore]
    public HojaResponsabilidad HojaResponsabilidad { get; set; }
}
