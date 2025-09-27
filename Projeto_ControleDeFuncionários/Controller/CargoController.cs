using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Update;
using Projeto_ControleDeFuncionários.Services.Interfaces;

namespace Projeto_ControleDeFuncionários.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpPost("registerCargo")]
        public async Task<IActionResult> RegisterCargo([FromBody] CargoRequestDto cargoRequestDto)
        {
            var response = await _cargoService.RegisterAsync(cargoRequestDto);
            return Ok(response);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCargos()
        {
            var response = await _cargoService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _cargoService.GetByIdAsync(id);

            if (response == null)
                return NotFound("Cargo não encontrado.");

            return Ok(response);
        }

        [HttpPatch("updateCargo/{id}")]
        public async Task<IActionResult> UpdateCargo(int id, [FromBody] CargoUpdateDto cargoUpdateDto)
        {
            var success = await _cargoService.UpdateCargoAsync(id, cargoUpdateDto);
            if (!success) return NotFound("Cargo não encontrado.");
            return Ok("Cargo atualizado com sucesso!");
        }

        [HttpDelete("deleteCargo/{id}")]
        public async Task<IActionResult> DeleteCargo(int id)
        {
            var cargo = await _cargoService.GetByIdAsync(id);

            if (cargo == null)
                return NotFound("Cargo não encontrado.");

            await _cargoService.DeleteCargoAsync(id);
            return Ok("Cargo deletado com sucesso!");
        }
    }

}