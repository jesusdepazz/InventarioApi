using Inventory.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class HojasResponsabilidadController : ControllerBase
{
    private readonly InventarioContext _context;

    public HojasResponsabilidadController(InventarioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CrearHoja([FromBody] HojaResponsabilidadDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        bool hojaExiste = await _context.HojasResponsabilidad
            .AnyAsync(h => h.HojaNo == dto.HojaNo);

        if (hojaExiste)
            return BadRequest(new { mensaje = "Ya existe una hoja con este Correlativo." });

        var codigosEquipo = dto.Equipos.Select(eq => eq.Codificacion).ToList();
        var equiposEnOtraHoja = await _context.HojaEquipos
            .Where(eq => codigosEquipo.Contains(eq.Codificacion))
            .Select(eq => eq.Codificacion)
            .ToListAsync();

        if (equiposEnOtraHoja.Any())
            return BadRequest(new { mensaje = "Los siguientes equipos ya están asignados a otra hoja: " + string.Join(", ", equiposEnOtraHoja) });

        var hoja = new HojaResponsabilidad
        {
            HojaNo = dto.HojaNo,
            Motivo = dto.Motivo,
            Comentarios = dto.Comentarios,
            FechaCreacion = DateTime.Now,
            Estado = dto.Estado,
            SolvenciaNo = dto.SolvenciaNo,
            FechaSolvencia = dto.FechaSolvencia,
            Observaciones = dto.Observaciones,
            Empleados = dto.Empleados.Select(e => new HojaEmpleado
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Puesto = e.Puesto,
                Departamento = e.Departamento
            }).ToList(),
            Equipos = dto.Equipos.Select(eq => new HojaEquipo
            {
                Codificacion = eq.Codificacion,
                Marca = eq.Marca,
                Modelo = eq.Modelo,
                Serie = eq.Serie,
                Tipo = eq.Tipo,
                TipoEquipo = eq.TipoEquipo,
                Estado = eq.Estado,
                Ubicacion = eq.Ubicacion
            }).ToList()
        };

        _context.HojasResponsabilidad.Add(hoja);
        await _context.SaveChangesAsync();

        return Ok(hoja);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetHoja(int id)
    {
        var hoja = await _context.HojasResponsabilidad
            .Include(h => h.Empleados)
            .Include(h => h.Equipos)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (hoja == null)
            return NotFound();

        return Ok(hoja);
    }

    [HttpGet]
    public async Task<IActionResult> ListarHojas()
    {
        var hojas = await _context.HojasResponsabilidad
            .Include(h => h.Empleados)
            .Include(h => h.Equipos)
            .ToListAsync();

        return Ok(hojas);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarHoja(int id)
    {
        var hoja = await _context.HojasResponsabilidad
            .Include(h => h.Empleados)
            .Include(h => h.Equipos)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (hoja == null)
            return NotFound(new { mensaje = "No se encontró la hoja con el ID especificado." });

        _context.HojasResponsabilidad.Remove(hoja);
        await _context.SaveChangesAsync();

        return Ok(new { mensaje = "Hoja eliminada correctamente." });
    }

}
