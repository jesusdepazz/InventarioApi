using Inventory.Data;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SuministrosController : ControllerBase
{
    private readonly InventarioContext _context;
}
