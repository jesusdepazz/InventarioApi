using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoEquiposController : ControllerBase
    {
        private readonly InventarioContext _context;
        public CatalogoEquiposController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Set<CatalogoEquipo>().ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CatalogoEquipo dto)
        {
            _context.Set<CatalogoEquipo>().Add(dto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }
    }
}
