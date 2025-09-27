using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.DTOs.Update;

namespace Projeto_ControleDeFuncionários.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> DeleteUserAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto> GetByIdAsync(int id);
        Task<UserResponseDto> RegisterAsync(UserRequestDto userDto);
        Task<UserResponseDto> UpdateAsync(UserRequestUpdateDto userDto);
        Task UpdatePasswordAsync(UserRequestUpdatePasswordDto passDto);
    }
}
