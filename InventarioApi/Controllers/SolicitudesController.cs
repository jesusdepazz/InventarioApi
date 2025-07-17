using System.Text.Json;
using InventarioApi.Models;
using Inventory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly InventarioContext _context;

        public SolicitudesController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicitudes()
        {
            return await _context.Solicitudes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return solicitud;
        }

        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            var asignacionesExistentes = await _context.Asignaciones
                .Where(a => a.CodificacionEquipo == solicitud.CodificacionEquipo)
                .ToListAsync();

            if (asignacionesExistentes.Any())
            {
                return BadRequest("Este equipo ya está asignado a otro empleado. Debe desasignarlo antes de crear una solicitud.");
            }

            _context.Solicitudes.Add(solicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSolicitud), new { id = solicitud.Id }, solicitud);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            _context.Solicitudes.Remove(solicitud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}/estado")]
        public async Task<IActionResult> ActualizarEstado(int id, [FromBody] JsonElement body)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null) return NotFound();

            if (solicitud.Estado == "Aprobada")
            {
                return BadRequest("No se puede modificar una solicitud aprobada.");
            }

            if (body.TryGetProperty("estado", out var estadoProp))
            {
                solicitud.Estado = estadoProp.GetString();
                await _context.SaveChangesAsync();
                return NoContent();
            }

            return BadRequest("Falta el campo 'estado'");
        }

    }
}
