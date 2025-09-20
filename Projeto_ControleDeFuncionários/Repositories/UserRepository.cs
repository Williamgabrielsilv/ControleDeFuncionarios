using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Banco_de_dados;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;


namespace Projeto_ControleDeFuncionários.Repositories
{
        
    public class UserRepository(banco_de_dados context) : IUserRepository
    {
        private readonly banco_de_dados _context = context; //Construtor
        public async Task<UserResponseDto?> GetByEmailAsync(string email)
        {
            
            return UserMapper.ToResponseDto(await _context.Users.FirstOrDefaultAsync(u => u.Email == email));
        }
        public async Task<UserResponseDto> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return UserMapper.ToResponseDto(user);
        }

        
        // READ
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // UPDATE
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

       
    }


}
