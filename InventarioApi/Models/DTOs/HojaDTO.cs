public class HojaEmpleadoDTO
{
    public string EmpleadoId { get; set; }
    public string Nombre { get; set; }
    public string Puesto { get; set; }
    public string Departamento { get; set; }
}

public class HojaEquipoDTO
{
    public string Codificacion { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Serie { get; set; }
    public string Tipo { get; set; }
    public string TipoEquipo { get; set; }
    public string Estado { get; set; }
    public string Ubicacion { get; set; }
    public string FechaIngreso { get; set; }
}

public class HojaResponsabilidadDTO
{
    public string HojaNo { get; set; }
    public string Motivo { get; set; }
    public string? Comentarios { get; set; }
    public string Estado { get; set; }
    public string? SolvenciaNo { get; set; }
    public DateTime? FechaSolvencia { get; set; } = DateTime.Now;
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
    public string Observaciones { get; set; }
    public string Accesorios { get; set; }

    public List<HojaEmpleadoDTO> Empleados { get; set; } = new();
    public List<HojaEquipoDTO> Equipos { get; set; } = new();
}
