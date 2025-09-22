using InventarioApi.Models;
using Inventory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventarioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HojaSolvenciasController : ControllerBase
    {
        private readonly InventarioContext _context;

        public HojaSolvenciasController(InventarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<HojaSolvencia>> CrearSolvencia(int hojaResponsabilidadId, string observaciones)
        {
            var hojaResp = await _context.HojasResponsabilidad
                .Include(h => h.Empleados)
                .Include(h => h.Equipos)
                .FirstOrDefaultAsync(h => h.Id == hojaResponsabilidadId);

            if (hojaResp == null)
                return BadRequest("No se encontró la Hoja de Responsabilidad.");

            var empleados = string.Join(", ", hojaResp.Empleados
                .Select(e => $" {e.EmpleadoId} - {e.Nombre} - {e.Puesto} - {e.Departamento}"));

            var equipos = string.Join(", ", hojaResp.Equipos
                .Select(eq => $"{eq.Codificacion} {eq.Marca} {eq.Modelo} ({eq.Ubicacion})"));

            var solvencia = new HojaSolvencia
            {
                SolvenciaNo = Guid.NewGuid().ToString().Substring(0, 8),
                FechaSolvencia = DateTime.Now,
                Observaciones = observaciones,
                HojaResponsabilidadId = hojaResp.Id,
                HojaNo = hojaResp.HojaNo,
                FechaHoja = hojaResp.FechaCreacion,
                Empleados = empleados,
                Equipos = equipos,
                FechaRegistro = DateTime.Now
            };

            _context.Solvencias.Add(solvencia);

            hojaResp.Estado = "Inactiva";

            await _context.SaveChangesAsync();

            return Ok(solvencia);
        }

        [HttpGet("historico")]
        public async Task<ActionResult<IEnumerable<object>>> GetHistorico()
        {
            var historico = await _context.Solvencias
                .Select(s => new
                {
                    s.SolvenciaNo,
                    s.FechaSolvencia,
                    s.Empleados,
                    s.Equipos,
                    s.HojaNo,
                    s.Observaciones
                })
                .ToListAsync();

            return Ok(historico);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarSolvencia(int id)
        {
            var solvencia = await _context.Solvencias.FindAsync(id);
            if (solvencia == null)
            {
                return NotFound("No se encontró la solvencia.");
            }

            _context.Solvencias.Remove(solvencia);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Solvencia eliminada correctamente." });
        }


    }
}
