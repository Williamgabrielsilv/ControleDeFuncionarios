using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;

namespace Projeto_ControleDeFuncionarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AfastamentoController : ControllerBase
    {
        private readonly IAfastamentoRepository _afastamentoRepository;

        public AfastamentoController(IAfastamentoRepository afastamentoRepository)
        {
            _afastamentoRepository = afastamentoRepository;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] AfastamentoRequestDto dto)
        {
            if (dto.DataFim < dto.DataInicio)
                return BadRequest("A data final não pode ser menor que a data inicial.");

            var afastamento = AfastamentoMapper.ToModel(dto);
            var criado = await _afastamentoRepository.CreateAsync(afastamento);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado.Id }, AfastamentoMapper.ToResponseDto(criado));
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = await _afastamentoRepository.GetAllAsync();
            return Ok(AfastamentoMapper.ToResponseDtoList(lista));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var afastamento = await _afastamentoRepository.GetByIdAsync(id);
            if (afastamento == null)
                return NotFound("Afastamento não encontrado.");

            return Ok(AfastamentoMapper.ToResponseDto(afastamento));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var afastamento = await _afastamentoRepository.GetByIdAsync(id);
            if (afastamento == null)
                return NotFound("Afastamento não encontrado.");

            await _afastamentoRepository.DeleteAsync(id);
            return Ok("Afastamento deletado com sucesso.");
        }
    }
}
