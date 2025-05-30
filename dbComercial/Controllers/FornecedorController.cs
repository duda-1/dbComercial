using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _service;

        public FornecedorController(IFornecedorService service)
        {
            _service = service;
        }

        [HttpPost("adicionar")]
        public async Task<ActionResult<Fornecedor>> Adicionar([FromBody] Fornecedor fornecedor)
        {
            await _service.AdicionarFornecedor(fornecedor);
            return Ok(fornecedor);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = await _service.ListarFornecedores();
            return Ok(lista);
        }

        [HttpGet("buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var fornecedor = await _service.BuscarFornecedorPorId(id);
            if (fornecedor == null)
                return NotFound();
            return Ok(fornecedor);
        }

        [HttpPut("editar/{id}")]
        public async Task<IActionResult> Editar(int id, [FromBody] Fornecedor fornecedor)
        {
            try
            {
                await _service.EditarFornecedor(id, fornecedor);
                return Ok(fornecedor);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _service.RemoverFornecedor(id);
            return NoContent();
        }
    }
}
