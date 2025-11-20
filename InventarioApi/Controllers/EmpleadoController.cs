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
            var empleado = await _context.EmpleadosInfo
                .Include(e => e.DepartamentoInfo)
                .Where(e => e.Empleado == codigo)
                .Select(e => new
                {   
                    codigoEmpleado = e.Empleado,
                    nombre = e.Nombre,
                    puesto = e.Puesto,
                    departamento = e.DepartamentoInfo.Descripcion
                })
                .FirstOrDefaultAsync();

            if (empleado == null)
                return NotFound();

            return Ok(empleado);
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<object>>> BuscarEmpleados([FromQuery] string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return Ok(new List<object>());

            var empleados = await _context.EmpleadosInfo
                .Include(e => e.DepartamentoInfo)
                .Where(e => e.Nombre.Contains(nombre))
                .Select(e => new
                {
                    codigoEmpleado = e.Empleado,
                    nombre = e.Nombre,
                    puesto = e.Puesto,
                    departamento = e.DepartamentoInfo.Descripcion
                })
                .ToListAsync();

            return Ok(empleados);
        }

    }
}
