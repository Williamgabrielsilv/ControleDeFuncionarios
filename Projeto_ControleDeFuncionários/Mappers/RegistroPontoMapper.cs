using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionarios.Mappers
{
    public static class RegistroPontoMapper
    {
        public static RegistroPontoResponseDto ToResponseDto(RegistroPonto model)
        {
            var dto = new RegistroPontoResponseDto
            {
                Id = model.Id,
                FuncionarioId = model.FuncionarioId,
                Data = model.Data,
                CheckIn = model.Checking,
                CheckOut = model.Checkout,
                Observacao = model.Observacao
            };

            if (model.Checkout.HasValue)
            {
                var carga = model.Checkout.Value - model.Checking;
                dto.CargaHoraria = $"{carga.Hours}h {carga.Minutes}m";
            }

            return dto;
        }

        public static List<RegistroPontoResponseDto> ToResponseDtoList(List<RegistroPonto> registros)
        {
            return registros.Select(ToResponseDto).ToList();
        }
    }
}

