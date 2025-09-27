using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Mappers
{
    public static class AfastamentoMapper
    {
        public static Afastamento ToModel(AfastamentoRequestDto dto)
        {
            return new Afastamento
            {
                FuncionarioId = dto.FuncionarioId,
                DataInicio = dto.DataInicio,
                DataFim = dto.DataFim,
                Motivo = dto.Motivo
            };
        }

        public static AfastamentoResponseDto ToResponseDto(Afastamento model)
        {
            return new AfastamentoResponseDto
            {
                Id = model.Id,
                FuncionarioId = model.FuncionarioId,
                DataInicio = model.DataInicio,
                DataFim = model.DataFim,
                Motivo = model.Motivo
            };
        }

        public static List<AfastamentoResponseDto> ToResponseDtoList(List<Afastamento> afastamentos)
        {
            return afastamentos.Select(ToResponseDto).ToList();
        }
    }

}
