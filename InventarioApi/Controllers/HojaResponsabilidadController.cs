using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Models;
using Inventory.Data;

namespace InventarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HojaResponsabilidadController : ControllerBase
    {
        private readonly InventarioContext _context;

        public HojaResponsabilidadController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HojaResponsabilidad>>> GetHojas()
        {
            return await _context.HojaResponsabilidades.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HojaResponsabilidad>> GetHoja(int id)
        {
            var hoja = await _context.HojaResponsabilidades.FindAsync(id);

            if (hoja == null)
                return NotFound();

            return hoja;
        }

        [HttpPost]
        public async Task<ActionResult<HojaResponsabilidad>> PostHoja(HojaResponsabilidad hoja)
        {
            _context.HojaResponsabilidades.Add(hoja);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHoja), new { id = hoja.Id }, hoja);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoja(int id)
        {
            var hoja = await _context.HojaResponsabilidades.FindAsync(id);
            if (hoja == null)
                return NotFound();

            _context.HojaResponsabilidades.Remove(hoja);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
