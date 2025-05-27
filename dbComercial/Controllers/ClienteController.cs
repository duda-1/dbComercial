using AutoMapper;
using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _service;

        public ClienteController(IClienteService clienteService)
        {
            _service = clienteService;
        }

        // Adicionar cliente
        [HttpPost("adicionar-cliente")]
        public async Task<ActionResult<Cliente>> AdicionarCliente([FromBody] Cliente cliente)
        {
            await _service.AdicionarCliente(cliente);
            return Ok(cliente);
        }

        // Listar todos os clientes
        [HttpGet("listar-clientes")]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await _service.ListarClientes();
            return Ok(clientes);
        }

        // Buscar cliente por CPF
        [HttpGet("buscar-cliente/{cpf}")]
        public async Task<IActionResult> BuscarClientePorCpf(string cpf)
        {
            var cliente = await _service.BuscarClientePorCpf(cpf);
            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado." });
            }
            return Ok(cliente);
        }

        // Editar cliente
        [HttpPut("editar-cliente/{cpf}")]
        public async Task<IActionResult> EditarCliente(string cpf, [FromBody] Cliente cliente)
        {
            try
            {
                await _service.EditarCliente(cpf, cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // Remover cliente
        [HttpDelete("remover-cliente/{cpf}")]
        public async Task<IActionResult> RemoverCliente(string cpf)
        {
            await _service.RemoverCliente(cpf);
            return NoContent(); // 204
        }
    }
}
