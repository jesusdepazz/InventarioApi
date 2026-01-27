using InventarioApi.Models;
using Inventory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AsignacionesController : ControllerBase
{
    private readonly InventarioContext _context;

    public AsignacionesController(InventarioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CrearAsignacion([FromBody] Asignacion asignacion)
    {
        var yaAsignado = await _context.Asignaciones
            .AnyAsync(a => a.CodificacionEquipo == asignacion.CodificacionEquipo);

        if (yaAsignado)
        {
            return BadRequest("Este equipo ya está asignado a otro empleado");
        }

        _context.Asignaciones.Add(asignacion);
        await _context.SaveChangesAsync();

        return Ok(asignacion);
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asignacion>>> GetAsignaciones()
    {
        return await _context.Asignaciones
            .OrderByDescending(a => a.FechaAsignacion)
            .ToListAsync();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarAsignacion(int id)
    {
        var asignacion = await _context.Asignaciones.FindAsync(id);
        if (asignacion == null)
        {
            return NotFound();
        }

        _context.Asignaciones.Remove(asignacion);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
