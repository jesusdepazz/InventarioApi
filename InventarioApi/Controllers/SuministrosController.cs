using Inventory.Data;
using InventarioApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class SuministrosController : ControllerBase
{
    private readonly InventarioContext _context;

    public SuministrosController(InventarioContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Suministro>>> GetAll()
    {
        return await _context.Suministros.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Suministro>> Get(int id)
    {
        var s = await _context.Suministros.FindAsync(id);
        if (s == null) return NotFound();
        return s;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CrearSuministroDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nombre)) return BadRequest("Nombre requerido");

        var s = new Suministro
        {
            Nombre = dto.Nombre,
            Descripcion = dto.Descripcion,
            UnidadMedida = dto.UnidadMedida,
            StockTotal = 0,
            Activo = true
        };

        _context.Suministros.Add(s);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = s.Id }, s);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CrearSuministroDto dto)
    {
        var s = await _context.Suministros.FindAsync(id);
        if (s == null) return NotFound();

        s.Nombre = dto.Nombre;
        s.Descripcion = dto.Descripcion;
        s.UnidadMedida = dto.UnidadMedida;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var s = await _context.Suministros.FindAsync(id);
        if (s == null) return NotFound();

        _context.Suministros.Remove(s);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
