using AutoMapper;
using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _service;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper)
        {
            _service = funcionarioService;
            _mapper = mapper;
        }

        // Adicionar funcionário
        [HttpPost("adicionar-funcionario")]
        public async Task<ActionResult<Funcionario>> AdicionarFuncionario([FromBody] Funcionario funcionario)
        {
            await _service.AdicionarFuncionario(funcionario);
            return Ok(funcionario);
        }

        // Listar todos os funcionários
        [HttpGet("listar-funcionarios")]
        public async Task<IActionResult> ListarFuncionarios()
        {
            var funcionarios = await _service.ListarFuncionarios();
            return Ok(funcionarios);
        }

        // Editar funcionário
        [HttpPut("editar-funcionario/{idFuncionario}")]
        public async Task<IActionResult> EditarFuncionario(int idFuncionario, [FromBody] Funcionario funcionario)
        {
            try
            {
                await _service.EditarFuncionario(idFuncionario, funcionario);
                return Ok(funcionario);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // Remover funcionário
        [HttpDelete("remover-funcionario/{idFuncionario}")]
        public async Task<IActionResult> RemoverFuncionario(int idFuncionario)
        {
            await _service.RemoverFuncionario(idFuncionario);
            return NoContent();
        }
    }
}
