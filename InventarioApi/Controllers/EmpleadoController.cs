using Microsoft.AspNetCore.Mvc;
using Inventory.Data;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly InventarioContext _context;

        public EmpleadosController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<object>> GetEmpleadoPorCodigo(string codigo)
        {
            var codigoNorm = codigo.Trim().ToUpper();

            // 1. Buscar en la tabla de empleados HR (sin Include para evitar SqlNullValueException)
            var empleado = await _context.EmpleadosInfo
                .Where(e => e.Empleado.Trim().ToUpper() == codigoNorm)
                .Select(e => new
                {
                    codigoEmpleado = e.Empleado ?? "",
                    nombre         = e.Nombre   ?? "",
                    puesto         = e.Puesto   ?? "",
                    departamento   = _context.Departamentos
                        .Where(d => d.Codigo == e.Departamento)
                        .Select(d => d.Descripcion ?? "")
                        .FirstOrDefault() ?? ""
                })
                .FirstOrDefaultAsync();

            if (empleado != null)
                return Ok(empleado);

            // 2. Fallback: buscar en historial de asignaciones
            var asignacion = await _context.Asignaciones
                .Where(a => a.CodigoEmpleado.Trim().ToUpper() == codigoNorm)
                .Select(a => new
                {
                    codigoEmpleado = a.CodigoEmpleado,
                    nombre         = a.NombreEmpleado,
                    puesto         = a.Puesto,
                    departamento   = a.Departamento ?? ""
                })
                .FirstOrDefaultAsync();

            if (asignacion != null)
                return Ok(asignacion);

            // 3. Fallback: buscar en hojas de responsabilidad
            var hojaEmp = await _context.HojaEmpleados
                .Where(h => h.EmpleadoId.Trim().ToUpper() == codigoNorm)
                .Select(h => new
                {
                    codigoEmpleado = h.EmpleadoId,
                    nombre         = h.Nombre,
                    puesto         = h.Puesto,
                    departamento   = h.Departamento ?? ""
                })
                .FirstOrDefaultAsync();

            if (hojaEmp != null)
                return Ok(hojaEmp);

            return NotFound(new { mensaje = $"No se encontró el empleado con código '{codigo}'." });
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<object>>> BuscarEmpleados([FromQuery] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Ok(new List<object>());

            var empleados = await _context.EmpleadosInfo
                .Where(e => e.Nombre != null && e.Nombre.Contains(nombre))
                .Select(e => new
                {
                    codigoEmpleado = e.Empleado ?? "",
                    nombre         = e.Nombre   ?? "",
                    puesto         = e.Puesto   ?? "",
                    departamento   = _context.Departamentos
                        .Where(d => d.Codigo == e.Departamento)
                        .Select(d => d.Descripcion ?? "")
                        .FirstOrDefault() ?? ""
                })
                .ToListAsync();

            return Ok(empleados);
        }

    }
}
