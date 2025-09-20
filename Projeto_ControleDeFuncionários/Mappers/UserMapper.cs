using Microsoft.AspNetCore.Identity;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Helpers;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Mappers
{
    public static class UserMapper
    {
        public static User ToModel(this UserRequestDto UserRequestDto)
        {
            return new User

            {
                Nome = UserRequestDto.Nome,
                CPF = UserRequestDto.CPF,
                Email = UserRequestDto.Email,
                Celular = UserRequestDto.Celular,
                LevelAccess = (int)UserRequestDto.LevelAccess,
                DataDeAdmissao = DateTime.Now,
                DataDeNascimento = UserRequestDto.DataDeNascimento,
                Senha = PasswordHasher.ToBcrypt(UserRequestDto.Senha),
            };
        }
        public static UserResponseDto? ToResponseDto(User user)
        {
            if (user.Id == 0) 
                return null;

            return new UserResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                CPF = user.CPF,
                Celular = user.Celular,
                Email = user.Email,
                DataDeNascimento = user.DataDeNascimento,
                DepartamentoId = user.DepartamentoId,
                Valid = user.Valid, 
            };
        }

    }
}
