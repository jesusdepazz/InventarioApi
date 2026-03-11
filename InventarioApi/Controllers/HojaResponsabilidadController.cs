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

        if (dto.Empleados == null || !dto.Empleados.Any())
            return BadRequest(new { mensaje = "Debe agregar al menos un empleado." });

        if (dto.Equipos == null || !dto.Equipos.Any())
            return BadRequest(new { mensaje = "Debe agregar al menos un equipo." });

        int cantidadConMismoCorrelativo = await _context.HojasResponsabilidad
            .CountAsync(h => h.HojaNo == dto.HojaNo);

        if (cantidadConMismoCorrelativo >= 2)
            return BadRequest(new
            {
                mensaje = "Ya existen dos hojas con este Correlativo. No se puede crear una tercera."
            });

        var codigosEquipo = dto.Equipos
            .Where(eq => !string.IsNullOrWhiteSpace(eq.Codificacion))
            .Select(eq => eq.Codificacion)
            .ToList();

        var equiposEnOtraHoja = await _context.HojaEquipos
            .Where(eq => codigosEquipo.Contains(eq.Codificacion))
            .Select(eq => eq.Codificacion)
            .ToListAsync();

        if (equiposEnOtraHoja.Any())
            return BadRequest(new
            {
                mensaje = "Los siguientes equipos ya están asignados a otra hoja: " +
                          string.Join(", ", equiposEnOtraHoja)
            });

        var hoja = new HojaResponsabilidad
        {
            TipoHoja = dto.TipoHoja,
            HojaNo = dto.HojaNo,
            Motivo = dto.Motivo,
            Comentarios = dto.Comentarios,
            FechaCreacion = DateTime.Now,
            Estado = dto.Estado,
            SolvenciaNo = dto.SolvenciaNo,
            FechaSolvencia = dto.FechaSolvencia,
            Observaciones = dto.Observaciones,
            Accesorios = dto.Accesorios,
            JefeInmediato = dto.JefeInmediato,
            Version = 0,

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
                TipoEquipo = eq.TipoEquipo,
                Ubicacion = eq.Ubicacion,
                FechaIngreso = eq.FechaIngreso,
                Estado = eq.Estado,
                NumeroAsignado = eq.NumeroAsignado,
                Extension = eq.Extension,
                Imei = eq.Imei,
                EquipoTipo = eq.EquipoTipo,
            }).ToList()
        };

        _context.HojasResponsabilidad.Add(hoja);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            mensaje = "Hoja creada correctamente",
            hoja.Id,
            hoja.HojaNo,
            hoja.Version
        });
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

    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarHoja(int id, [FromBody] HojaResponsabilidadDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (dto.Empleados == null || !dto.Empleados.Any())
            return BadRequest(new { mensaje = "Debe agregar al menos un empleado." });

        if (dto.Equipos == null || !dto.Equipos.Any())
            return BadRequest(new { mensaje = "Debe agregar al menos un equipo." });

        var hoja = await _context.HojasResponsabilidad
            .Include(h => h.Empleados)
            .Include(h => h.Equipos)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (hoja == null)
            return NotFound(new { mensaje = "Hoja no encontrada." });

        if (hoja.HojaNo != dto.HojaNo)
        {
            bool existe = await _context.HojasResponsabilidad
                .AnyAsync(h => h.HojaNo == dto.HojaNo && h.Id != id);

            if (existe)
                return BadRequest(new { mensaje = "Ya existe una hoja con este Correlativo." });
        }

        var codigosEquipo = dto.Equipos
            .Where(e => !string.IsNullOrWhiteSpace(e.Codificacion))
            .Select(e => e.Codificacion)
            .ToList();

        var equiposEnOtraHoja = await _context.HojaEquipos
            .Where(eq =>
                codigosEquipo.Contains(eq.Codificacion) &&
                eq.HojaResponsabilidadId != id
            )
            .Select(eq => eq.Codificacion)
            .ToListAsync();

        if (equiposEnOtraHoja.Any())
            return BadRequest(new
            {
                mensaje = "Los siguientes equipos ya están asignados a otra hoja: " +
                          string.Join(", ", equiposEnOtraHoja)
            });

        hoja.HojaNo = dto.HojaNo;
        hoja.Motivo = dto.Motivo;
        hoja.Comentarios = dto.Comentarios;
        hoja.Estado = dto.Estado;
        hoja.SolvenciaNo = dto.SolvenciaNo;
        hoja.FechaSolvencia = dto.FechaSolvencia;
        hoja.Observaciones = dto.Observaciones;
        hoja.Accesorios = dto.Accesorios;
        hoja.JefeInmediato = dto.JefeInmediato;

        hoja.Empleados.Clear();
        foreach (var e in dto.Empleados)
        {
            hoja.Empleados.Add(new HojaEmpleado
            {
                EmpleadoId = e.EmpleadoId,
                Nombre = e.Nombre,
                Puesto = e.Puesto,
                Departamento = e.Departamento
            });
        }

        hoja.Equipos.Clear();
        foreach (var eq in dto.Equipos)
        {
            hoja.Equipos.Add(new HojaEquipo
            {
                Codificacion = eq.Codificacion,
                Marca = eq.Marca,
                Modelo = eq.Modelo,
                Serie = eq.Serie,
                TipoEquipo = eq.TipoEquipo,
                Ubicacion = eq.Ubicacion,
                FechaIngreso = eq.FechaIngreso,
                Estado = eq.Estado
            });
        }

        hoja.Version += 1;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            mensaje = "Hoja actualizada correctamente",
            hoja.Id,
            hoja.HojaNo,
            hoja.Version
        });
    }

}
