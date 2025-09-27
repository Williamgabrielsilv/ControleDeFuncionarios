using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Mappers
{
    public static class AuthMapper
    {
        public static AuthResponseDto ToResponse(User user)
        {
            return new AuthResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Token = ""
            };
        }
    }
}
