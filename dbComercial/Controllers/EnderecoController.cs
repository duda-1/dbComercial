using AutoMapper;
using Core;
using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("adicionar-endereco")]
        public ActionResult<Endereco> AdicionarEndereco([FromBody] Endereco endereco)
        {
            _service.Adicionar(endereco);
            return Ok(endereco);
        }

        [HttpGet("listar-enderecos")]
        public ActionResult<List<Endereco>> ListarEnderecos()
        {
            var enderecos = _service.Listar();
            return Ok(enderecos);
        }

        [HttpGet("buscar-endereco-por-id")]
        public ActionResult<Endereco> BuscarPorId([FromQuery] int id)
        {
            var endereco = _service.BuscarEnderecoPorId(id);
            if (endereco == null)
                return NotFound("Endereço não encontrado.");
            return Ok(endereco);
        }

        [HttpGet("listar-por-cidade")]
        public ActionResult<List<Endereco>> ListarPorCidade([FromQuery] string cidade)
        {
            var enderecos = _service.ListarPorCidade(cidade);
            return Ok(enderecos);
        }

        [HttpPut("editar-endereco")]
        public IActionResult EditarEndereco([FromBody] Endereco endereco)
        {
            _service.Editar(endereco);
            return NoContent();
        }

        [HttpDelete("deletar-endereco")]
        public IActionResult DeletarEndereco([FromQuery] int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}
