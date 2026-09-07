using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioFisicoController : ControllerBase
    {
        private readonly InventarioContext _context;
        public InventarioFisicoController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var totalEquipos = await _context.Equipos.CountAsync();
            var totalTomas = await _context.Set<TomaFisica>().CountAsync();
            var totalFaltantes = await _context.Set<FaltanteSobrante>().CountAsync(fs => fs.Tipo == "Faltante");

            return Ok(new { totalEquipos, totalTomas, totalFaltantes });
        }

        [HttpPost("toma")]
        public async Task<IActionResult> RegistrarToma([FromBody] TomaFisica dto)
        {
            _context.Set<TomaFisica>().Add(dto);
            await _context.SaveChangesAsync();

            // calcular faltantes/sobrantes simplificado
            if (dto.Items != null)
            {
                foreach (var item in dto.Items)
                {
                    var sistemaCount = await _context.Equipos.CountAsync(e => e.Id == item.EquipoId);
                    var falt = new FaltanteSobrante
                    {
                        EquipoId = item.EquipoId,
                        CantidadSistema = sistemaCount,
                        CantidadContada = item.CantidadContada,
                    };
                    _context.Set<FaltanteSobrante>().Add(falt);
                }
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(ObtenerToma), new { id = dto.Id }, dto);
        }

        [HttpGet("toma/{id}")]
        public async Task<IActionResult> ObtenerToma(int id)
        {
            var toma = await _context.Set<TomaFisica>().Include(t => t.Items).FirstOrDefaultAsync(t => t.Id == id);
            if (toma == null) return NotFound();
            return Ok(toma);
        }

        [HttpGet("faltantes")]
        public async Task<IActionResult> GetFaltantes()
        {
            var list = await _context.Set<FaltanteSobrante>().Where(f => f.Tipo == "Faltante").ToListAsync();
            return Ok(list);
        }
    }
}
