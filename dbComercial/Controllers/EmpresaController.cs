using AutoMapper;
using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaService _service;

        public EmpresaController(IEmpresaService empresaRepository)
        {
            _service = empresaRepository;
        }

        // Adicionar
        [HttpPost("adicionar-empresa")]
        public async Task<ActionResult<Empresa>> AdicionarEmpresa([FromBody] Empresa empresa)
        {
            await _service.AdicionarEmpresa(empresa);
            return Ok(empresa);
        }

        // Listar
        [HttpGet("listar-empresas")]
        public async Task<IActionResult> ListarEmpresas()
        {
            var empresas = await _service.ListarEmpresa();
            return Ok(empresas);
        }

        // Editar
        [HttpPut("editar-empresa/{cnpj}")]
        public async Task<IActionResult> EditarEmpresa(string cnpj, [FromBody] Empresa empresa)
        {
            try
            {
                await _service.EditarEmpresa(cnpj, empresa);
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // Remover
        [HttpDelete("remover-empresa/{cnpj}")]
        public async Task<IActionResult> RemoverEmpresa(string cnpj)
        {
            await _service.RemoverEmpresa(cnpj);
            return NoContent();
        }

        // Buscar por CNPJ
        //[HttpGet("buscar-empresa/{cnpj}")]
        //public async Task<ActionResult<Empresa>> BuscarEmpresa(string cnpj)
        //{
        //    var empresa = await _service.BuscarEmpresaPorCnpj(cnpj);

        //    if (empresa == null)
        //    {
        //        return NotFound(new { message = "Empresa não encontrada." });
        //    }

        //    return Ok(empresa);
        //}

    }
}
