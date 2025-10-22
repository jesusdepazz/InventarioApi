using Inventory.Data;
using InventarioApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Models.DTOs;

[ApiController]
[Route("api/[controller]")]
public class InventarioController : ControllerBase
{
    private readonly InventarioContext _context;

    public InventarioController(InventarioContext context)
    {
        _context = context;
    }

    [HttpGet("suministro/{suministroId}")]
    public async Task<IActionResult> GetInventarioPorSuministro(int suministroId)
    {
        var inventario = await _context.InventarioSuministros
            .Where(i => i.SuministroId == suministroId)
            .ToListAsync();

        return Ok(inventario);
    }

    [HttpGet("movimientos")]
    public async Task<IActionResult> GetMovimientos([FromQuery] int? suministroId, [FromQuery] int? ubicacionId)
    {
        var q = _context.MovimientoSuministros
            .Include(m => m.Suministro)
            .Include(m => m.UbicacionOrigen)
            .Include(m => m.UbicacionDestino)
            .AsQueryable();

        if (suministroId.HasValue)
            q = q.Where(m => m.SuministroId == suministroId.Value);

        if (ubicacionId.HasValue)
            q = q.Where(m => m.UbicacionOrigenId == ubicacionId.Value || m.UbicacionDestinoId == ubicacionId.Value);

        var list = await q.OrderByDescending(m => m.FechaMovimiento).ToListAsync();
        return Ok(list);
    }

    [HttpPost("movimientos")]
    public async Task<IActionResult> RegistrarMovimiento([FromBody] MovimientoDto dto)
    {
        if (dto.Cantidad <= 0) return BadRequest("Cantidad debe ser mayor a cero.");
        var tipo = dto.TipoMovimiento?.Trim();

        if (tipo != "Entrada" && tipo != "Salida" && tipo != "Traslado")
            return BadRequest("TipoMovimiento debe ser 'Entrada', 'Salida' o 'Traslado'.");

        var suministro = await _context.Suministros.FindAsync(dto.SuministroId);
        if (suministro == null) return NotFound("Suministro no encontrado.");

        using var tx = await _context.Database.BeginTransactionAsync();
        try
        {
            if (tipo == "Entrada")
            {
                if (!dto.UbicacionDestinoId.HasValue)
                    return BadRequest("UbicacionDestinoId es requerida para Entrada.");

                var invDest = await _context.InventarioSuministros
                    .FirstOrDefaultAsync(i => i.SuministroId == dto.SuministroId && i.UbicacionId == dto.UbicacionDestinoId.Value);

                if (invDest == null)
                {
                    invDest = new InventarioSuministro
                    {
                        SuministroId = dto.SuministroId,
                        UbicacionId = dto.UbicacionDestinoId.Value,
                        Cantidad = dto.Cantidad
                    };
                    _context.InventarioSuministros.Add(invDest);
                }
                else
                {
                    invDest.Cantidad += dto.Cantidad;
                }

                suministro.StockTotal += dto.Cantidad;

                var mov = new MovimientoSuministro
                {
                    SuministroId = dto.SuministroId,
                    TipoMovimiento = "Entrada",
                    UbicacionDestinoId = dto.UbicacionDestinoId,
                    Cantidad = dto.Cantidad,
                    FechaMovimiento = DateTime.UtcNow,
                    RealizadoPor = dto.RealizadoPor,
                    Observacion = dto.Observacion
                };
                _context.MovimientoSuministros.Add(mov);
            }
            else if (tipo == "Salida")
            {
                if (!dto.UbicacionOrigenId.HasValue)
                    return BadRequest("UbicacionOrigenId es requerida para Salida.");

                var invOrig = await _context.InventarioSuministros
                    .FirstOrDefaultAsync(i => i.SuministroId == dto.SuministroId && i.UbicacionId == dto.UbicacionOrigenId.Value);

                if (invOrig == null || invOrig.Cantidad < dto.Cantidad)
                    return BadRequest("Stock insuficiente en la ubicación origen.");

                invOrig.Cantidad -= dto.Cantidad;
                suministro.StockTotal -= dto.Cantidad;

                var mov = new MovimientoSuministro
                {
                    SuministroId = dto.SuministroId,
                    TipoMovimiento = "Salida",
                    UbicacionOrigenId = dto.UbicacionOrigenId,
                    Cantidad = dto.Cantidad,
                    FechaMovimiento = DateTime.UtcNow,
                    RealizadoPor = dto.RealizadoPor,
                    Observacion = dto.Observacion
                };
                _context.MovimientoSuministros.Add(mov);
            }
            else
            {
                if (!dto.UbicacionOrigenId.HasValue || !dto.UbicacionDestinoId.HasValue)
                    return BadRequest("UbicacionOrigenId y UbicacionDestinoId son requeridos para Traslado.");

                if (dto.UbicacionOrigenId == dto.UbicacionDestinoId)
                    return BadRequest("Origen y destino no pueden ser iguales.");

                var invOrig = await _context.InventarioSuministros
                    .FirstOrDefaultAsync(i => i.SuministroId == dto.SuministroId && i.UbicacionId == dto.UbicacionOrigenId.Value);

                if (invOrig == null || invOrig.Cantidad < dto.Cantidad)
                    return BadRequest("Stock insuficiente en la ubicación origen.");

                invOrig.Cantidad -= dto.Cantidad;

                var invDest = await _context.InventarioSuministros
                    .FirstOrDefaultAsync(i => i.SuministroId == dto.SuministroId && i.UbicacionId == dto.UbicacionDestinoId.Value);

                if (invDest == null)
                {
                    invDest = new InventarioSuministro
                    {
                        SuministroId = dto.SuministroId,
                        UbicacionId = dto.UbicacionDestinoId.Value,
                        Cantidad = dto.Cantidad
                    };
                    _context.InventarioSuministros.Add(invDest);
                }
                else
                {
                    invDest.Cantidad += dto.Cantidad;
                }

                var mov = new MovimientoSuministro
                {
                    SuministroId = dto.SuministroId,
                    TipoMovimiento = "Traslado",
                    UbicacionOrigenId = dto.UbicacionOrigenId,
                    UbicacionDestinoId = dto.UbicacionDestinoId,
                    Cantidad = dto.Cantidad,
                    FechaMovimiento = DateTime.UtcNow,
                    RealizadoPor = dto.RealizadoPor,
                    Observacion = dto.Observacion
                };
                _context.MovimientoSuministros.Add(mov);
            }

            await _context.SaveChangesAsync();
            await tx.CommitAsync();
            return Ok(new { mensaje = "Movimiento registrado correctamente" });
        }
        catch (Exception ex)
        {
            await tx.RollbackAsync();
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpDelete("movimientos/{id}")]
    public async Task<IActionResult> EliminarMovimiento(int id)
    {
        var mov = await _context.MovimientoSuministros.FindAsync(id);
        if (mov == null) return NotFound();

        _context.MovimientoSuministros.Remove(mov);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
