using AutoMapper;
using Core;
using Core._01_Services.Interface;
using Core._02_Repository;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
     
        private readonly IMapper _mapper;
        private readonly IEnderecoService _service;

        //public EnderecoController(IEnderecoService service, IMapper mapper)
        //{
        //    _service = service;
        //    _mapper = mapper;
        //}
        public EnderecoController(IEnderecoService enderecoRepository)
        {
            _service=enderecoRepository;
        }

        //Adicionar
        [HttpPost("adicionar-endereco")]
        public async Task<ActionResult<Endereco>> AdicionarEndereco([FromBody] Endereco endereco)
        {
            // Chama o método assíncrono de adicionar da service
            await _service.AdicionarEndereco(endereco);

            // Retorna o status de sucesso com o objeto Endereco
            return Ok(endereco);
        }

        //Listar
        [HttpGet("listar-enderecos")]
        public async Task<IActionResult> ListarEnderecos()
        {
            var enderecos = await _service.ListarEndereco();
            return Ok(enderecos);
        }


        //[HttpGet("buscar-endereco-por-id")]
        //public ActionResult<Endereco> BuscarPorId([FromQuery] int id)
        //{
        //    var endereco = _service.BuscarEnderecoPorId(id);
        //    if (endereco == null)
        //        return NotFound("Endereço não encontrado.");
        //    return Ok(endereco);
        //}

        //[HttpGet("listar-por-cidade")]
        //public ActionResult<List<Endereco>> ListarPorCidade([FromQuery] string cidade)
        //{
        //    var enderecos = _service.ListarPorCidade(cidade);
        //    return Ok(enderecos);
        //}

        //Editar
        [HttpPut("editar-endereco/{idEndereco}")]
        public async Task<IActionResult> EditarEndereco(int idEndereco, [FromBody] Endereco endereco)
        {
            try
            {
                // Chama o serviço para editar o endereço
                await _service.EditarEndereco(idEndereco, endereco);

                // Retorna o endereço atualizado
                return Ok(endereco);
            }
            catch (Exception ex)
            {
                // Se o endereço não for encontrado ou ocorrer algum erro
                return NotFound(new { message = ex.Message });
            }
        }




        //Remover
        [HttpDelete("remover-endereco/{id}")]
        public async Task<IActionResult> RemoverEndereco(int id)
        {
            // Chama o método de remoção da service
            await _service.RemoverEndereco(id);

            // Retorna uma resposta de sucesso
            return NoContent(); // Retorna status 204 (sem conteúdo) após remoção
        }

    }
}
