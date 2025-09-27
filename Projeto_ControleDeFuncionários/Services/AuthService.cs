using Microsoft.AspNetCore.Identity;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Helpers;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using Projeto_ControleDeFuncionários.Services.Interfaces;

namespace Projeto_ControleDeFuncionários.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }


        public async Task<AuthResponseDto> LoginAsync(AuthRequestDto authDto)
        {
            var user = await _userRepository.GetByEmailAsync(authDto.Email);

            if (user == null || !PasswordHasher.Verify(authDto.Senha, user.Senha))
                throw new UnauthorizedAccessException("Senha e/ou Email inválidos");

            var response = AuthMapper.ToResponse(user);
            response.Token = _tokenService.GenerateToken(user);

            return response;
        }
    }
}
