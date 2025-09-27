using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionarios.Mappers;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;

namespace Projeto_ControleDeFuncionarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EspelhoPontoController : ControllerBase
    {
        private readonly IRegistroPontoRepository _registroPontoRepository;
        private readonly IAfastamentoRepository _afastamentoRepository;

        public EspelhoPontoController(IRegistroPontoRepository registroPontoRepository, IAfastamentoRepository afastamentoRepository)
        {
            _registroPontoRepository = registroPontoRepository;
            _afastamentoRepository = afastamentoRepository;
        }

        [HttpPost("checking")]
        public async Task<IActionResult> CheckIng([FromBody] CheckingDto dto)
        {
            var hoje = DateTime.UtcNow.Date;

            if (await _afastamentoRepository.EstaAfastadoAsync(dto.FuncionarioId, hoje))
                return BadRequest("Funcionário está afastado hoje, check-in não permitido.");

            var jaExiste = await _registroPontoRepository.GetByFuncionarioAndDateAsync(dto.FuncionarioId, hoje);
            if (jaExiste != null)
                return BadRequest("Check-in já realizado para hoje.");

            var registro = new RegistroPonto
            {
                FuncionarioId = dto.FuncionarioId,
                Data = hoje,
                Checking = DateTime.UtcNow
            };

            var criado = await _registroPontoRepository.CreateAsync(registro);

            return CreatedAtAction(nameof(RegistroDeHoje), new { funcionarioId = criado.FuncionarioId },
                RegistroPontoMapper.ToResponseDto(criado));
        }

        [HttpPut("checkout")]
        public async Task<IActionResult> CheckOut([FromBody] CheckoutDto dto)
        {
            var hoje = DateTime.UtcNow.Date;

            var registro = await _registroPontoRepository.GetByFuncionarioAndDateAsync(dto.FuncionarioId, hoje);
            if (registro == null)
                return NotFound("Nenhum check-ing encontrado para hoje.");

            if (registro.Checkout != null)
                return BadRequest("Check-out já registrado.");

            var agora = DateTime.UtcNow;

            if (agora <= registro.Checking)
            {
                return BadRequest("Check-out não pode ser antes do check-in.");
            }

            if ((agora - registro.Checking) < TimeSpan.FromMinutes(30))
                return BadRequest("Tempo mínimo de trabalho para check-out é 30 minutos.");

            registro.Checkout = agora;

            await _registroPontoRepository.UpdateAsync(registro);

            return Ok(RegistroPontoMapper.ToResponseDto(registro));
        }

        [HttpGet("historico/{funcionarioId}")]
        public async Task<IActionResult> Historico(int funcionarioId)
        {
            var registros = await _registroPontoRepository.GetByFuncionarioAsync(funcionarioId);
            if (registros == null || !registros.Any())
                return NotFound("Nenhum registro de ponto encontrado.");

            var dtoList = RegistroPontoMapper.ToResponseDtoList(registros);
            return Ok(dtoList);
        }

        [HttpGet("hoje/{funcionarioId}")]
        public async Task<IActionResult> RegistroDeHoje(int funcionarioId)
        {
            var hoje = DateTime.UtcNow.Date;
            var registro = await _registroPontoRepository.GetByFuncionarioAndDateAsync(funcionarioId, hoje);

            if (registro == null)
                return Ok("Nenhum ponto registrado para hoje.");

            return Ok(RegistroPontoMapper.ToResponseDto(registro));
        }
    }
}

