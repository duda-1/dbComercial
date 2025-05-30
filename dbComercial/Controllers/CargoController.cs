using Core._01_Services.Interface;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _service;

        public CargoController(ICargoService cargoService)
        {
            _service = cargoService;
        }

        // Adicionar
        [HttpPost("adicionar-cargo")]
        public async Task<ActionResult<Cargos>> AdicionarCargo([FromBody] Cargos cargo)
        {
            await _service.AdicionarCargo(cargo);
            return Ok(cargo);
        }

        // Listar
        [HttpGet("listar-cargos")]
        public async Task<IActionResult> ListarCargos()
        {
            var cargos = await _service.ListarCargos();
            return Ok(cargos);
        }

        // Buscar por ID
        [HttpGet("buscar-cargo/{id}")]
        public async Task<IActionResult> BuscarCargoPorId(int id)
        {
            var cargo = await _service.BuscarCargoPorId(id);
            if (cargo == null)
                return NotFound(new { message = "Cargo não encontrado." });

            return Ok(cargo);
        }

        // Editar
        [HttpPut("editar-cargo/{idCargo}")]
        public async Task<IActionResult> EditarCargo(int idCargo, [FromBody] Cargos cargo)
        {
            try
            {
                await _service.EditarCargo(idCargo, cargo);
                return Ok(cargo);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // Remover
        [HttpDelete("remover-cargo/{id}")]
        public async Task<IActionResult> RemoverCargo(int id)
        {
            await _service.RemoverCargo(id);
            return NoContent();
        }
    }
}
