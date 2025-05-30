using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoMercadoriaController : ControllerBase
    {
        private readonly ITipoMercadoriaService _service;

        public TipoMercadoriaController(ITipoMercadoriaService service)
        {
            _service = service;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<TipoMercadoria>> Adicionar([FromBody] TipoMercadoria tipo)
        {
            await _service.AdicionarTipoMercadoria(tipo);
            return Ok(tipo);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var tipos = await _service.ListarTipoMercadorias();
            return Ok(tipos);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var tipo = await _service.BuscarTipoMercadoriaPorId(id);
            if (tipo == null) return NotFound();
            return Ok(tipo);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] TipoMercadoria tipo)
        {
            try
            {
                await _service.EditarTipoMercadoria(id, tipo);
                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _service.RemoverTipoMercadoria(id);
            return NoContent();
        }
    }
}
