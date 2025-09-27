using Microsoft.AspNetCore.Identity;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.DTOs.Update;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Mappers
{
    public class CargoMapper
    {
        public static Cargo ToModel(CargoRequestDto dto)
        {
            return new Cargo
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                SalarioBase = dto.SalarioBase,
            };
        }
        public static CargoResponseDto ToResponseDto(Cargo Cargo)
        {
            return new CargoResponseDto
            {
                CargoId = Cargo.CargoId,
                Nome = Cargo.Nome,
                Descricao = Cargo.Descricao
            };
        }
        public static List<CargoResponseDto> ToResponseDtoList(List<Cargo> Cargos)
        {
            return Cargos.Select(d => ToResponseDto(d)).ToList();
        }
        public static void UpdateModelFromDto(CargoResponseDto Cargo, CargoUpdateDto dto)
        {
            if (!string.IsNullOrWhiteSpace(dto.Nome))
                Cargo.Nome = dto.Nome;
            if (!string.IsNullOrWhiteSpace(dto.Descricao))
                Cargo.Descricao = dto.Descricao;
            if (dto.SalarioBase.HasValue)
                Cargo.SalarioBase = dto.SalarioBase.Value;
        }

    }
}
