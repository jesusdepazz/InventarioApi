using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inventory.Data;
using InventarioApi.Models.Suministros;
using ExcelDataReader;
using System.Text;

namespace InventarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuministrosController : ControllerBase
    {
        private readonly InventarioContext _context;

        public SuministrosController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suministro>>> GetSuministros()
        {
            var suministros = await _context.Suministros
                .Include(s => s.Entradas)
                .Include(s => s.Salidas)
                .ToListAsync();

            return Ok(suministros);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Suministro>> GetSuministro(int id)
        {
            var suministro = await _context.Suministros
                .Include(s => s.Entradas)
                .Include(s => s.Salidas)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (suministro == null)
            {
                return NotFound();
            }

            return Ok(suministro);
        }

        [HttpPost]
        public async Task<ActionResult<Suministro>> CreateSuministro(Suministro suministro)
        {
            if (suministro == null)
                return BadRequest("Datos inválidos.");

            if (suministro.CantidadActual < 0)
                return BadRequest("La cantidad no puede ser negativa.");

            suministro.DateTime = DateTime.Now;

            _context.Suministros.Add(suministro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSuministro), new { id = suministro.Id }, suministro);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuministro(int id, Suministro suministro)
        {
            if (id != suministro.Id)
            {
                return BadRequest("Los ID no coinciden.");
            }

            var existing = await _context.Suministros.FindAsync(id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.NombreProducto = suministro.NombreProducto;
            existing.UbicacionProducto = suministro.UbicacionProducto;
            existing.DateTime = DateTime.Now;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuministro(int id)
        {
            var suministro = await _context.Suministros.FindAsync(id);

            if (suministro == null)
            {
                return NotFound();
            }

            _context.Suministros.Remove(suministro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/recalcular")]
        public async Task<IActionResult> RecalcularInventario(int id)
        {
            var suministro = await _context.Suministros
                .Include(s => s.Entradas)
                .Include(s => s.Salidas)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (suministro == null)
            {
                return NotFound();
            }

            int entradas = suministro.Entradas.Sum(e => e.CantidadProducto);
            int salidas = suministro.Salidas.Sum(s => s.CantidadProducto);

            suministro.CantidadActual = entradas - salidas;

            await _context.SaveChangesAsync();
            return Ok(new { cantidadActual = suministro.CantidadActual });
        }

        [HttpPost("importar-excel")]
        public async Task<IActionResult> ImportarExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Debes subir un archivo Excel válido.");

            var suministros = new List<Suministro>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var stream = file.OpenReadStream())
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet();
                var table = result.Tables[0];

                for (int i = 1; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i];

                    var suministro = new Suministro
                    {
                        NombreProducto = row[0]?.ToString(),
                        UbicacionProducto = row[1]?.ToString(),
                        CantidadActual = int.TryParse(row[2]?.ToString(), out var cantidad) ? cantidad : 0
                    };

                    suministros.Add(suministro);
                }
            }

            await _context.Suministros.AddRangeAsync(suministros);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = $"{suministros.Count} suministros importados correctamente." });
        }

        [HttpDelete("todos")]
        public async Task<IActionResult> DeleteAllSuministros()
        {
            var salidas = _context.SalidaSuministros;
            _context.SalidaSuministros.RemoveRange(salidas);

            var entradas = _context.EntradaSuministros;
            _context.EntradaSuministros.RemoveRange(entradas);

            var suministros = _context.Suministros;
            _context.Suministros.RemoveRange(suministros);

            await _context.SaveChangesAsync();

            await _context.Database.ExecuteSqlRawAsync("DBCC CHECKIDENT ('Suministros', RESEED, 0)");

            return Ok(new { mensaje = "Todos los suministros y sus movimientos fueron eliminados. ID reiniciado a 0." });
        }

    }
}
