using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using Projeto_ControleDeFuncionários.DTOs.Response;
using System.Security.Cryptography;
using System.Text;
using Projeto_ControleDeFuncionários.DTOs.Update;



namespace Projeto_ControleDeFuncionarios.Controller
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
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            var response = users.Select(u => new Projeto_ControleDeFuncionários.DTOs.Response.UserResponseDto
            {
                Id = u.Id,
                Nome = u.Nome,
                CPF = u.CPF,
                Celular = u.Celular,
                Email = u.Email,
                DataDeNascimento = u.DataDeNascimento,
                DepartamentoId = u.DepartamentoId
            });

            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound("Usuário não encontrado.");

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
        [HttpPatch("updateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)

        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            // Atualiza apenas os campos enviados
            if (!string.IsNullOrEmpty(userUpdateDto.Nome))
                user.Nome = userUpdateDto.Nome;

            if (!string.IsNullOrEmpty(userUpdateDto.Email))
                user.Email = userUpdateDto.Email;

            if (!string.IsNullOrEmpty(userUpdateDto.Celular))
                user.Celular = userUpdateDto.Celular;

            if (userUpdateDto.DepartamentoId.HasValue)
                user.DepartamentoId = userUpdateDto.DepartamentoId.Value;

            if (!string.IsNullOrEmpty(userUpdateDto.Senha))
            {
                using var sha256 = SHA256.Create();
                user.Senha = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(userUpdateDto.Senha)));
            }

            await _userRepository.UpdateAsync(user);

            return Ok("Usuário atualizado com sucesso!");
        }
        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound("Usuário não encontrado.");

            await _userRepository.DeleteAsync(id);

            return Ok("Usuário deletado com sucesso!");
        }

    }
}
