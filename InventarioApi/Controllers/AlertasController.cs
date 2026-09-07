using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertasController : ControllerBase
    {
        private readonly InventarioContext _context;
        public AlertasController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _context.Set<Alerta>().ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Set<Alerta>().FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Alerta dto)
        {
            _context.Set<Alerta>().Add(dto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Alerta dto)
        {
            if (id != dto.Id) return BadRequest();
            _context.Entry(dto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Set<Alerta>().FindAsync(id);
            if (item == null) return NotFound();
            _context.Set<Alerta>().Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
