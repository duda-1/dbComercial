using Core._01_Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("loginCliente")]
    public class LoginController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public LoginController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public class LoginRequest
        {
            public string CPFCliente { get; set; }
            public string SenhaCliente { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var cliente = await _clienteService.LoginCliente(request.CPFCliente, request.SenhaCliente);

                if (cliente == null)
                {
                    return Unauthorized(new { message = "CPF ou senha inválidos." });
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
