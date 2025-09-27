using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<UserResponseDto> CreateAsync(UserRequestDto user);
        Task<UserResponseDto> UpdateAsync(UserRequestUpdateDto userRequestUpdateDto);
        Task UpdatePasswordAsync(UserRequestUpdatePasswordDto passDto);
        Task<UserResponseDto>GetByIdAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
    
}
