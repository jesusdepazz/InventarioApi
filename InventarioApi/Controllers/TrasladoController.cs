using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Models;
using Inventory.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventarioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrasladosController : ControllerBase
    {
        private readonly InventarioContext _context;

        public TrasladosController(InventarioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Traslado>>> GetAll()
        {
            return await _context.Traslados.ToListAsync();
        }

        [HttpGet("{no}")]
        public async Task<ActionResult<Traslado>> GetByNo(string no)
        {
            var traslado = await _context.Traslados.FindAsync(no);
            if (traslado == null)
                return NotFound();

            return traslado;
        }

        [HttpPost]
        public async Task<ActionResult<Traslado>> Create([FromBody] Traslado nuevoTraslado)
        {
            if (nuevoTraslado == null || string.IsNullOrEmpty(nuevoTraslado.No))
                return BadRequest("Datos de traslado inválidos.");

            if (await _context.Traslados.AnyAsync(t => t.No == nuevoTraslado.No))
                return Conflict("Ya existe un traslado con ese número.");

            _context.Traslados.Add(nuevoTraslado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByNo), new { no = nuevoTraslado.No }, nuevoTraslado);
        }

        [HttpPut("{no}")]
        public async Task<IActionResult> Update(string no, [FromBody] Traslado updatedTraslado)
        {
            if (no != updatedTraslado.No)
                return BadRequest("El número de traslado no coincide.");

            var traslado = await _context.Traslados.FindAsync(no);
            if (traslado == null)
                return NotFound();

            traslado.FechaEmision = updatedTraslado.FechaEmision;
            traslado.Solicitante = updatedTraslado.Solicitante;
            traslado.DescripcionEquipo = updatedTraslado.DescripcionEquipo;
            traslado.Motivo = updatedTraslado.Motivo;
            traslado.UbicacionDesde = updatedTraslado.UbicacionDesde;
            traslado.UbicacionHasta = updatedTraslado.UbicacionHasta;
            traslado.Status = updatedTraslado.Status;
            traslado.FechaLiquidacion = updatedTraslado.FechaLiquidacion;
            traslado.Razon = updatedTraslado.Razon;

            _context.Entry(traslado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{no}")]
        public async Task<IActionResult> Delete(string no)
        {
            var traslado = await _context.Traslados.FindAsync(no);
            if (traslado == null)
                return NotFound();

            _context.Traslados.Remove(traslado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("consultar-nit/{nit}")]
        //public async Task<IActionResult> ConsultarNit(string nit)
        //{
        //    using var client = new HttpClient();
        //    client.DefaultRequestHeaders.Add("Authorization", "Bearer NDM0MzA3NzU=");
        //    client.DefaultRequestHeaders.Add("Accept", "application/json");

        //    var body = new { NIT = nit };
        //    var response = await client.PostAsJsonAsync("https://minirtu.edxsolutions.com/api/GetRTUData", body);

        //    if (!response.IsSuccessStatusCode)
        //        return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

        //    var data = await response.Content.ReadAsStringAsync();
        //    return Ok(data);
        //}

    }
}
