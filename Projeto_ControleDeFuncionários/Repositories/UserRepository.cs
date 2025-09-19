using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Banco_de_dados;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;

namespace Projeto_ControleDeFuncionários.Repositories
{
    
    public class UserRepository(banco_de_dados context) : IUserRepository
    {
        private readonly banco_de_dados _context = context; //Construtor

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
