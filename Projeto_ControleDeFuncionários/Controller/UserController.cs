using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using Projeto_ControleDeFuncionários.DTOs.Response;
using System.Security.Cryptography;
using System.Text;
using Projeto_ControleDeFuncionários.DTOs.Update;
using Projeto_ControleDeFuncionários.Mappers;



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
    
            //Transforma o request para o modelo do banco
            var user = UserMapper.ToModel(userRequestDto);
            var response = await _userRepository.CreateAsync(user);
            
            return Ok(response);

        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();

            var response = UserMapper.ToResponseDtoList((List<User>)users);


            return Ok(response);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound("Usuário não encontrado.");

            var response = UserMapper.ToResponseDto(user);

            return Ok(response);
        }

        [HttpPatch("updateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return NotFound("Usuário não encontrado.");

            UserMapper.UpdateModelFromDto(user, userUpdateDto);

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
