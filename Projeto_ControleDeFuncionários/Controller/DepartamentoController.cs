using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Update;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;

namespace Projeto_ControleDeFuncionários.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoRepository _departamentoRepository;
        public DepartamentoController(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }
        [HttpPost("registerDepartamento")]
        public async Task<IActionResult> registerDepartamento([FromBody] DepartamentoRequestDto departamentoRequestDto)
        {
            
            //Transforma o request para o modelo do banco
            var departamento = DepartamentoMapper.ToModel(departamentoRequestDto);
            var response = await _departamentoRepository.CreateAsync(departamento);

            return Ok(response);

        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllDepartamentos()
        {
            var departamentos = await _departamentoRepository.GetAllAsync();

            var response = DepartamentoMapper.ToResponseDtoList((List<Departamento>)departamentos);


            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var departamento = await _departamentoRepository.GetByIdAsync(id);

            if (departamento == null)
                return NotFound("Departamento não encontrado.");

            var response = DepartamentoMapper.ToResponseDto(departamento);

            return Ok(response);
        }

        [HttpPatch("updateDepartamento/{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] DepartamentoUpdateDto departamentoUpdateDto)
        {
            var departamento = await _departamentoRepository.GetByIdAsync(id);
            if (departamento == null)
                return NotFound("Departamento não encontrado.");

            DepartamentoMapper.UpdateModelFromDto(departamento, departamentoUpdateDto);

            await _departamentoRepository.UpdateAsync(departamento);

            return Ok("Departamento atualizado com sucesso!");
        }

        [HttpDelete("deleteDepartamento/{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var departamento = await _departamentoRepository.GetByIdAsync(id);

            if (departamento == null)
                return NotFound("Departamento não encontrado não encontrado.");

            await _departamentoRepository.DeleteAsync(id);

            return Ok("Departamento deletado com sucesso!");
        }

    }
}
