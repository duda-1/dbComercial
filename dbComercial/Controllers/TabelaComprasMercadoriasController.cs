using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TabelaComprasMercadoriasController : ControllerBase
    {
        private readonly ITabelaComprasMercadoriasService _service;

        public TabelaComprasMercadoriasController(ITabelaComprasMercadoriasService service)
        {
            _service = service;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<TabelaComprasMercadorias>> Adicionar([FromBody] TabelaComprasMercadorias entidade)
        {
            await _service.Adicionar(entidade);
            return Ok(entidade);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _service.Listar();
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var entidade = await _service.BuscarPorId(id);
            if (entidade == null)
                return NotFound();

            return Ok(entidade);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] TabelaComprasMercadorias entidade)
        {
            try
            {
                await _service.Editar(id, entidade);
                return Ok(entidade);
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
