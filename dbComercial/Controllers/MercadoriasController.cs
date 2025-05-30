using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MercadoriasController : ControllerBase
    {
        private readonly IMercadoriasService _service;

        public MercadoriasController(IMercadoriasService service)
        {
            _service = service;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<Mercadorias>> Adicionar([FromBody] Mercadorias mercadoria)
        {
            await _service.AdicionarMercadoria(mercadoria);
            return Ok(mercadoria);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = await _service.ListarMercadorias();
            return Ok(lista);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var mercadoria = await _service.BuscarMercadoriaPorId(id);
            if (mercadoria == null)
                return NotFound();
            return Ok(mercadoria);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Mercadorias mercadoria)
        {
            try
            {
                await _service.EditarMercadoria(id, mercadoria);
                return Ok(mercadoria);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _service.RemoverMercadoria(id);
            return NoContent();
        }
    }
}
