using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?>GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
    
    /*CREATE
        Task<User> CreateAsync(User user);

        // READ
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();

        // UPDATE
        Task UpdateAsync(User user);

        // DELETE
        Task DeleteAsync(int id);*/
    }
    
}
