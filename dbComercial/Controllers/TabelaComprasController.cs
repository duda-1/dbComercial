using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TabelaComprasController : ControllerBase
    {
        private readonly ITabelaComprasService _service;

        public TabelaComprasController(ITabelaComprasService service)
        {
            _service = service;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<TabelaCompras>> Adicionar([FromBody] TabelaCompras compra)
        {
            await _service.Adicionar(compra);
            return Ok(compra);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var compras = await _service.Listar();
            return Ok(compras);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var compra = await _service.BuscarPorId(id);
            if (compra == null)
                return NotFound();

            return Ok(compra);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] TabelaCompras compra)
        {
            try
            {
                await _service.Editar(id, compra);
                return Ok(compra);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _service.Remover(id);
            return NoContent();
        }
    }
}
