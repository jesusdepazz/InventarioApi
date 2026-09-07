using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolizaSeguroController : ControllerBase
    {
        private readonly InventarioContext _context;
        public PolizaSeguroController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Set<PolizaSeguro>().ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Set<PolizaSeguro>().FindAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PolizaSeguro dto)
        {
            _context.Set<PolizaSeguro>().Add(dto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PolizaSeguro dto)
        {
            if (id != dto.Id) return BadRequest();
            _context.Entry(dto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Set<PolizaSeguro>().FindAsync(id);
            if (item == null) return NotFound();
            _context.Set<PolizaSeguro>().Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
