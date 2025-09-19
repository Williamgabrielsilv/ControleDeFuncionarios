using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using System.Security.Cryptography;
using System.Text;

    

namespace Projeto_ControleDeFuncionários.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRequestDto userRequestDto)
        {
            //verifica se existe um usuário com o email cadastrado
            bool existingUser = await _userRepository.GetByEmailAsync(userRequestDto.Email) != null;
            if (existingUser)
            {
                return BadRequest("Email já cadastrado.");
            }

            //Transforma senha em Hash
            using var sha256 = SHA256.Create();
            var senhaHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(userRequestDto.Senha)));

            //Transforma o request para o modelo do banco
            var user = new User
            {
                Nome = userRequestDto.Nome,
                CPF = userRequestDto.CPF,
                Email = userRequestDto.Email,
                Senha = senhaHash,
                LevelAccess = (int)userRequestDto.LevelAccess,
                Celular = userRequestDto.Celular,
                DataDeNascimento = userRequestDto.DataDeNascimento,
                DepartamentoId = userRequestDto.DepartamentoId
            };
            var userDb = await _userRepository.CreateAsync(user);
                //Transforma o modelo do banco em response
            var response = new UserResponseDto
            {
                Id = user.Id,
                Nome = user.Nome,
                CPF = user.CPF,
                Celular = user.Celular,
                Email = user.Email,
                DataDeNascimento = user.DataDeNascimento,
                DepartamentoId = user.DepartamentoId
            };
            return Ok(response);

        }
    }
}
