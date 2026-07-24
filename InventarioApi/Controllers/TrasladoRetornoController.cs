using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Models;
using Inventory.Data;
using InventarioApi.Models.DTOs;

namespace InventarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrasladoRetornosController : ControllerBase
    {
        private readonly InventarioContext _context;

        public TrasladoRetornosController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var traslados = await _context.TrasladoRetornos
                .Include(t => t.Empleados)
                .Include(t => t.Equipos)
                .ToListAsync();

            return Ok(traslados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrasladoRetorno>> GetTrasladoRetorno(int id)
        {
            var traslado = await _context.TrasladoRetornos.FindAsync(id);

            if (traslado == null)
                return NotFound();

            return traslado;
        }

        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> PostTrasladoRetorno(TrasladoRetorno traslado)
        {
            var equipoExiste = await _context.Equipos
                .AnyAsync(e => e.Codificacion == traslado.Equipo);

            if (!equipoExiste)
                return BadRequest("La codificación del equipo no existe.");
=======
        public async Task<IActionResult> PostTrasladoRetorno([FromBody] TrasladoRetornoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.Equipos == null || !dto.Equipos.Any())
                return BadRequest("Debe agregar al menos un equipo");

            var tipoRetiro = (dto.TipoRetiro ?? "proveedor").ToLower();

            if (tipoRetiro == "empleado")
            {
                if (dto.Empleados == null || !dto.Empleados.Any())
                    return BadRequest("Debe agregar al menos un empleado.");
            }
            else // proveedor
            {
                if (string.IsNullOrWhiteSpace(dto.NombreProveedor))
                    return BadRequest("Debe ingresar el nombre del proveedor.");
            }

            var codigos = dto.Equipos.Select(e => e.Equipo).ToList();

            var existentes = await _context.Equipos
                .Where(e => codigos.Contains(e.Codificacion))
                .Select(e => e.Codificacion)
                .ToListAsync();

            var noExisten = codigos.Except(existentes).ToList();
            if (noExisten.Any())
                return BadRequest($"Equipos no existen: {string.Join(", ", noExisten)}");

            var traslado = new TrasladoRetorno
            {
                No = dto.No,
                FechaPase = dto.FechaPase,
                MotivoSalida = dto.MotivoSalida,
                UbicacionRetorno = dto.UbicacionRetorno,
                FechaRetorno = dto.FechaRetorno,
                TipoRetiro = tipoRetiro,
                Estado = "Vigente",
                CodigoProveedor = dto.CodigoProveedor,
                TelefonoProveedor = dto.TelefonoProveedor,
                PersonaRetira = dto.PersonaRetira,
                NombreProveedor = dto.NombreProveedor,
                NombreContacto = dto.NombreContacto,
                Identificacion = dto.Identificacion,

                Empleados = dto.Empleados.Select(emp => new TrasladoRetornoEmpleado
                {
                    EmpleadoId = emp.EmpleadoId,
                    Nombre = emp.Nombre,
                    Puesto = emp.Puesto,
                    Departamento = emp.Departamento
                }).ToList(),

                Equipos = dto.Equipos.Select(eq => new TrasladoRetornoEquipo
                {
                    Equipo = eq.Equipo,
                    DescripcionEquipo = eq.DescripcionEquipo,
                    Marca = eq.Marca,
                    Modelo = eq.Modelo,
                    Serie = eq.Serie
                }).ToList()
            };
>>>>>>> jesusdepazz

            _context.TrasladoRetornos.Add(traslado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTrasladoRetorno),
                new { id = traslado.Id },
                traslado
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrasladoRetorno(int id, TrasladoRetorno traslado)
        {
            if (id != traslado.Id)
                return BadRequest("El ID del traslado no coincide.");

            var equipoExiste = await _context.Equipos
                .AnyAsync(e => e.Codificacion == traslado.Equipo);

            if (!equipoExiste)
                return BadRequest("La codificación del equipo no existe.");

            _context.Entry(traslado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrasladoRetornoExists(id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpGet("detalle/{id}")]
        public async Task<IActionResult> ObtenerDetalle(int id)
        {
            var traslado = await _context.TrasladoRetornos
                .Include(t => t.Equipos)
                .Include(t => t.Empleados)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (traslado == null)
                return NotFound();

            return Ok(traslado);
        }

        [HttpPatch("{id}/anular")]
        public async Task<IActionResult> AnularTrasladoRetorno(int id)
        {
            var traslado = await _context.TrasladoRetornos.FindAsync(id);

            if (traslado == null)
                return NotFound();

            if (traslado.Estado == "Anulado")
                return BadRequest("El registro ya está anulado.");

            traslado.Estado = "Anulado";
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Registro anulado correctamente.", id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrasladoRetorno(int id)
        {
            var traslado = await _context.TrasladoRetornos.FindAsync(id);

            if (traslado == null)
                return NotFound();

            _context.TrasladoRetornos.Remove(traslado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrasladoRetornoExists(int id)
        {
            return _context.TrasladoRetornos.Any(e => e.Id == id);
        }
    }
}
