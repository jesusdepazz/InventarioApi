using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Models;
using Inventory.Data;

namespace InventarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrasladoRetornosController : ControllerBase
    {
        private readonly InventarioContext _context;

        public TrasladoRetornosController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrasladoRetorno>>> GetTrasladoRetornos()
        {
            return await _context.TrasladoRetornos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrasladoRetorno>> GetTrasladoRetorno(int id)
        {
            var traslado = await _context.TrasladoRetornos.FindAsync(id);

            if (traslado == null)
                return NotFound();

            return traslado;
        }

        [HttpPost]
        public async Task<IActionResult> PostTrasladoRetorno(TrasladoRetorno traslado)
        {
            var equipoExiste = await _context.Equipos
                .AnyAsync(e => e.Codificacion == traslado.Equipo);

            if (!equipoExiste)
                return BadRequest("La codificación del equipo no existe.");

            _context.TrasladoRetornos.Add(traslado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTrasladoRetorno),
                new { id = traslado.Id },
                traslado
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrasladoRetorno(int id, TrasladoRetorno traslado)
        {
            if (id != traslado.Id)
                return BadRequest("El ID del traslado no coincide.");

            var equipoExiste = await _context.Equipos
                .AnyAsync(e => e.Codificacion == traslado.Equipo);

            if (!equipoExiste)
                return BadRequest("La codificación del equipo no existe.");

            _context.Entry(traslado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrasladoRetornoExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrasladoRetorno(int id)
        {
            var traslado = await _context.TrasladoRetornos.FindAsync(id);

            if (traslado == null)
                return NotFound();

            _context.TrasladoRetornos.Remove(traslado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrasladoRetornoExists(int id)
        {
            return _context.TrasladoRetornos.Any(e => e.Id == id);
        }
    }
}
