using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryApi.Models;
using Inventory.Data;

namespace InventoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private readonly InventarioContext _context;
        private readonly IWebHostEnvironment _env;

        public EquiposController(InventarioContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEquipos()
        {
            var equiposConAsignaciones = await _context.Equipos
                .Select(e => new
                {
                    e.Id,
                    e.OrderCompra,
                    e.Factura,
                    e.Proveedor,
                    e.Tipo,
                    e.Codificacion,
                    e.Estado,
                    e.Marca,
                    e.Modelo,
                    e.Serie,
                    e.Imei,
                    e.NumeroAsignado,
                    e.Extension,
                    e.Especificaciones,
                    e.Accesorios,
                    e.Ubicacion,
                    e.FechaIngreso,
                    e.ImagenRuta,

                    Asignaciones = _context.Asignaciones
                        .Where(a => a.CodificacionEquipo == e.Codificacion)
                        .Select(a => new {
                            a.CodigoEmpleado,
                            a.NombreEmpleado,
                            a.Puesto
                        })
                        .ToList()
                })
                .ToListAsync();

            return Ok(equiposConAsignaciones);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Equipo>> GetEquipo(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);

            if (equipo == null)
            {
                return NotFound();
            }

            return equipo;
        }

        [HttpGet("por-codificacion/{codificacion}")]
        public async Task<IActionResult> GetEquipoPorCodificacion(string codificacion)
        {
            var equipo = await _context.Equipos
                .Where(e => e.Codificacion == codificacion)
                .Select(e => new
                {
                    codificacion = e.Codificacion,
                    marca = e.Marca,
                    modelo = e.Modelo,
                    serie = e.Serie,
                    estado = e.Estado,
                    tipo = e.Tipo,
                    ubicacion = e.Ubicacion
                })
                .FirstOrDefaultAsync();

            if (equipo == null)
                return NotFound();

            return Ok(equipo);
        }


        [HttpPost]
        public async Task<ActionResult<Equipo>> PostEquipo([FromForm] EquipoDTO dto)
        {
            var existeDuplicado = await _context.Equipos.AnyAsync(e =>
                e.OrderCompra == dto.OrderCompra ||
                e.Factura == dto.Factura ||
                e.Codificacion == dto.Codificacion ||
                (!string.IsNullOrEmpty(dto.Serie) && e.Serie == dto.Serie)
            );

            if (await _context.Equipos.AnyAsync(e => e.OrderCompra == dto.OrderCompra))
                return BadRequest("Ya existe un equipo con la misma Orden de Compra.");

            if (await _context.Equipos.AnyAsync(e => e.Factura == dto.Factura))
                return BadRequest("Ya existe un equipo con la misma Factura.");

            if (await _context.Equipos.AnyAsync(e => e.Codificacion == dto.Codificacion))
                return BadRequest("Ya existe un equipo con la misma Codificación.");

            if (!string.IsNullOrEmpty(dto.Serie) &&
                await _context.Equipos.AnyAsync(e => e.Serie == dto.Serie))
                return BadRequest("Ya existe un equipo con la misma Serie.");

            string? rutaImagen = null;
            if (dto.Imagen != null && dto.Imagen.Length > 0)
            {
                var carpeta = Path.Combine(_env.WebRootPath, "images");
                Directory.CreateDirectory(carpeta);

                var nombreArchivo = $"{Guid.NewGuid()}{Path.GetExtension(dto.Imagen.FileName)}";
                var rutaCompleta = Path.Combine(carpeta, nombreArchivo);

                using (var stream = new FileStream(rutaCompleta, FileMode.Create))
                {
                    await dto.Imagen.CopyToAsync(stream);
                }

                rutaImagen = $"/images/{nombreArchivo}";
            }

            var equipo = new Equipo
            {
                OrderCompra = dto.OrderCompra,
                Factura = dto.Factura,
                Proveedor = dto.Proveedor,
                Tipo = dto.Tipo,
                Codificacion = dto.Codificacion,
                Estado = dto.Estado,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Serie = dto.Serie,
                Imei = dto.Imei,
                NumeroAsignado = dto.NumeroAsignado,
                Extension = dto.Extension,
                Especificaciones = dto.Especificaciones,
                Accesorios = dto.Accesorios,
                Ubicacion = dto.Ubicacion,
                FechaIngreso = dto.FechaIngreso,
                ImagenRuta = rutaImagen
            };

            _context.Equipos.Add(equipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, equipo);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipo(int id)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
            {
                return NotFound();
            }

            _context.Equipos.Remove(equipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarEquipo(int id, [FromForm] EquipoDTO dto)
        {
            var equipo = await _context.Equipos.FindAsync(id);
            if (equipo == null)
                return NotFound("Equipo no encontrado");

            equipo.Tipo = dto.Tipo;
            equipo.Codificacion = dto.Codificacion;
            equipo.Estado = dto.Estado;
            equipo.Marca = dto.Marca;
            equipo.Modelo = dto.Modelo;
            equipo.Serie = dto.Serie;
            equipo.Imei = dto.Imei;
            equipo.NumeroAsignado = dto.NumeroAsignado;
            equipo.Extension = dto.Extension;
            equipo.Especificaciones = dto.Especificaciones;
            equipo.Accesorios = dto.Accesorios;
            equipo.Ubicacion = dto.Ubicacion;
            equipo.FechaIngreso = dto.FechaIngreso;

            if (dto.Imagen != null && dto.Imagen.Length > 0)
            {
                var nombreArchivo = $"{Guid.NewGuid()}_{dto.Imagen.FileName}";
                var rutaCarpeta = Path.Combine(_env.WebRootPath, "uploads");

                if (!Directory.Exists(rutaCarpeta))
                    Directory.CreateDirectory(rutaCarpeta);

                var rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);
                using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    await dto.Imagen.CopyToAsync(stream);
                }

                equipo.ImagenRuta = $"/uploads/{nombreArchivo}";
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Equipo actualizado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar cambios: {ex.Message}");
            }
        }

    }

}
