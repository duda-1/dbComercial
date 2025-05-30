using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorMercadoriaController : ControllerBase
    {
        private readonly IFornecedorMercadoriaService _service;

        public FornecedorMercadoriaController(IFornecedorMercadoriaService service)
        {
            _service = service;
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> AdicionarRelacao([FromBody] FornecedorMercadoria relacao)
        {
            await _service.AdicionarRelacao(relacao);
            return Ok(relacao);
        }

        [HttpDelete("remover")]
        public async Task<IActionResult> RemoverRelacao([FromQuery] int fornecedorId, [FromQuery] int mercadoriaId)
        {
            await _service.RemoverRelacao(fornecedorId, mercadoriaId);
            return NoContent();
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarRelacoes()
        {
            var relacoes = await _service.ListarRelacoes();
            return Ok(relacoes);
        }

        [HttpGet("mercadorias-por-fornecedor/{fornecedorId}")]
        public async Task<IActionResult> ListarMercadorias(int fornecedorId)
        {
            var mercadorias = await _service.ListarMercadoriasPorFornecedor(fornecedorId);
            return Ok(mercadorias);
        }

        [HttpGet("fornecedores-por-mercadoria/{mercadoriaId}")]
        public async Task<IActionResult> ListarFornecedores(int mercadoriaId)
        {
            var fornecedores = await _service.ListarFornecedoresPorMercadoria(mercadoriaId);
            return Ok(fornecedores);
        }

    }
}
