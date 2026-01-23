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
        [HttpPost]
        public async Task<IActionResult> PostTrasladoRetorno([FromBody] TrasladoRetornoCreateDto dto)
        {
            foreach (var item in dto.Equipos)
            {
                var existe = await _context.Equipos
                    .AnyAsync(e => e.Codificacion == item.Equipo);

                if (dto.Equipos == null || !dto.Equipos.Any())
                    return BadRequest("Debe enviar al menos un equipo");
            }

            var traslado = new TrasladoRetorno
            {
                No = dto.No,
                FechaPase = dto.FechaPase,
                Solicitante = dto.Solicitante,
                MotivoSalida = dto.MotivoSalida,
                FechaRetorno = dto.FechaRetorno,
                Status = dto.Status,
                RazonNoLiquidada = dto.RazonNoLiquidada
            };

            traslado.Detalles = dto.Equipos.Select(e => new TrasladoRetornoDetalle
            {
                Equipo = e.Equipo,
                TrasladoRetorno = traslado   // 🔥 CLAVE
            }).ToList();

            _context.TrasladoRetornos.Add(traslado);
            await _context.SaveChangesAsync();

            return Ok(traslado);
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
    }
}
