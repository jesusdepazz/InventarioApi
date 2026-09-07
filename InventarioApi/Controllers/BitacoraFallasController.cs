using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraFallasController : ControllerBase
    {
        private readonly InventarioContext _context;
        public BitacoraFallasController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _context.Set<BitacoraFalla>().ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Set<BitacoraFalla>().FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BitacoraFalla dto)
        {
            _context.Set<BitacoraFalla>().Add(dto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BitacoraFalla dto)
        {
            if (id != dto.Id) return BadRequest();
            _context.Entry(dto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Set<BitacoraFalla>().FindAsync(id);
            if (item == null) return NotFound();
            _context.Set<BitacoraFalla>().Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
