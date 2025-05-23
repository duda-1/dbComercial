using AutoMapper;
using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDepartamentoService _service;


        public DepartamentoController(IDepartamentoService departamentoRepository)
        {
            _service = departamentoRepository;
        }

        // Adicionar
        [HttpPost("adicionar-departamento")]
        public async Task<ActionResult<Departamento>> AdicionarDepartamento([FromBody] Departamento departamento)
        {
            await _service.AdicionarDepartamento(departamento);
            return Ok(departamento);
        }

        // Listar
        [HttpGet("listar-departamentos")]
        public async Task<IActionResult> ListarDepartamentos()
        {
            var departamentos = await _service.ListarDepartamento();
            return Ok(departamentos);
        }

        // Editar
        [HttpPut("editar-departamento/{idDepartamento}")]
        public async Task<IActionResult> EditarDepartamento(int idDepartamento, [FromBody] Departamento departamento)
        {
            try
            {
                await _service.EditarDepartamento(idDepartamento, departamento);
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // Remover
        [HttpDelete("remover-departamento/{id}")]
        public async Task<IActionResult> RemoverDepartamento(int id)
        {
            await _service.RemoverDepartamento(id);
            return NoContent();
        }

     }
}
