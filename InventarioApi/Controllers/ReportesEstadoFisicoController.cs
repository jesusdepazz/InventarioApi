using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using InventoryApi.Models;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesEstadoFisicoController : ControllerBase
    {
        private readonly InventarioContext _context;
        public ReportesEstadoFisicoController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _context.Set<ReporteEstadoFisico>().ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReporteEstadoFisico dto)
        {
            _context.Set<ReporteEstadoFisico>().Add(dto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }
    }
}
