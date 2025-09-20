using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserResponseDto?>GetByEmailAsync(string email);
        Task<UserResponseDto> CreateAsync(User user);
    
    
        // READ
        Task<User?> GetByIdAsync(int id); 
        Task<IEnumerable<User>> GetAllAsync();

        // UPDATE
        Task UpdateAsync(User user);

        // DELETE
        Task DeleteAsync(int id);
    }
    
}
