using System;
using System.Collections.Generic;

namespace InventarioApi.Models
{
    public class HojaResponsabilidad
    {
        public int Id { get; set; }
        public string? HojaNo { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
        public string JefeInmediato { get; set; }
        public string MotivoActualizacion { get; set; }
        public string Comentarios { get; set; }

        // Datos del empleado asignado
        public string CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }

        // Datos del equipo asignado
        public string FechaEquipo { get; set; }
        public string CodigoEquipo { get; set; }
        public string Equipo { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Ubicacion { get; set; }
        public string Marca { get; set; }

        // Datos de responsabilidad

        public string Estado { get; set; }
        public string SolvenciaNo { get; set; }
        public DateTime FechaSolvencia { get; set; } = DateTime.Now;
        public string Observaciones { get; set; }

    }
}
