using Microsoft.AspNetCore.Identity;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.DTOs.Update;
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
                Cargo = UserRequestDto.Cargo,
                Salario = UserRequestDto.Salario,
                Email = UserRequestDto.Email,
                Celular = UserRequestDto.Celular,
                LevelAccess = (int)UserRequestDto.LevelAccess,
                DataDeAdmissao = DateTime.Now,
                DataDeNascimento = UserRequestDto.DataDeNascimento,
                Senha = PasswordHasher.ToBcrypt(UserRequestDto.Senha),
                Convenio = UserRequestDto.Convenio,
                Endereco = UserRequestDto.Endereco,

            };
        }
        public static UserResponseDto? ToResponseDto(User user)
        {
            if (user == null) 
                return null;

            return new UserResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Cargo = user.Cargo,
                CPF = user.CPF,
                Celular = user.Celular,
                Email = user.Email,
                DataDeNascimento = user.DataDeNascimento,
                Valid = user.Valid, 
            };
        }
        public static List<UserResponseDto> ToResponseDtoList(List<User> users)
        {
            return users.Select(ToResponseDto).Where(dto => dto != null).ToList()!;

        }

        public static User ToUpdateModel(UserRequestUpdateDto userRequestUpdateDto)
        {
            return new User
            {
                Id = userRequestUpdateDto.Id,
                Nome = userRequestUpdateDto.Name,
                CPF = userRequestUpdateDto.Cpf,
                Email = userRequestUpdateDto.Email,
                Celular = userRequestUpdateDto.Celular,
                LevelAccess = (int)userRequestUpdateDto.LevelAccess,
                DataDeNascimento = userRequestUpdateDto.DataDeNascimento
            };
        }
        public static User ToUpdatePasswordModel(UserRequestUpdatePasswordDto passDto)
        {
            return new User
            {
                Id = passDto.IdUser,
                Senha = passDto.NewPassword,
            };
        }

    }
}
