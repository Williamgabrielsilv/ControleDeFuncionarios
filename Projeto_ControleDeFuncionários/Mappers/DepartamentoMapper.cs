using Microsoft.AspNetCore.Identity;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.DTOs.Update;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Mappers
{
    public class DepartamentoMapper
    {
        public static Departamento ToModel(DepartamentoRequestDto dto)
        {
            return new Departamento
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao
            };
        }
        public static DepartamentoResponseDto ToResponseDto(Departamento departamento)
        {
            return new DepartamentoResponseDto
            {
                DepartamentoId = departamento.DepartamentoId,
                Nome = departamento.Nome,
                Descricao = departamento.Descricao
            };
        }
        public static List<DepartamentoResponseDto> ToResponseDtoList(List<Departamento> departamentos)
        {
            return departamentos.Select(d => ToResponseDto(d)).ToList();
        }
        public static void UpdateModelFromDto(Departamento departamento, DepartamentoUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Nome))
                departamento.Nome = dto.Nome;
            if (!string.IsNullOrWhiteSpace(dto.Descricao))
                departamento.Descricao = dto.Descricao;
        }
    }
}
