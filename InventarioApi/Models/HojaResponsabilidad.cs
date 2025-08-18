using System;
using System.Collections.Generic;

namespace InventarioApi.Models
{
    public class HojaResponsabilidad
    {
        public int Id { get; set; }
        public string? HojaNo { get; set; }
        public string JefeInmediato { get; set; }
        public string MotivoActualizacion { get; set; }
        public string AccesoriosEntregados { get; set; }
        public string Comentarios { get; set; }

        // Datos del empleado asignado
        public string CodigoEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }

        // Datos del equipo asignado
        public string CodigoEquipo { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Ubicacion { get; set; }
        public string Marca { get; set; }
    }
}
