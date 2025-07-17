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
                    nombre = e.Nombre,
                    puesto = e.Puesto,
                    departamento = e.DepartamentoInfo.Descripcion
                })
                .FirstOrDefaultAsync();

            if (empleado == null)
                return NotFound();

            return Ok(empleado);
        }

    }
}
