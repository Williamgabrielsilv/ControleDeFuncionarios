using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.Services.Interfaces;



namespace Projeto_ControleDeFuncionarios.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequestDto userDto)
        {
            try
            {
                var response = await _userService.RegisterAsync(userDto);
                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserRequestUpdateDto userDto)
        {
            try
            {
                var response = await _userService.UpdateAsync(userDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPatch("updatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UserRequestUpdatePasswordDto passDto)
        {
            try
            {
                await _userService.UpdatePasswordAsync(passDto);
                return Ok("Senha atualizada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUserAsync(id);
                return Ok("Usuário deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAllAsync();
            return Ok(response);

        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                
                return Ok(await _userService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }

        }


    }
}
