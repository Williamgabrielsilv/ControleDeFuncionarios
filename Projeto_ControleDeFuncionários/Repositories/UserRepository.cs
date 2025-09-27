using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Banco_de_dados;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Helpers;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using System;

namespace Projeto_ControleDeFuncionários.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly banco_de_dados _context;
        public UserRepository(banco_de_dados context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserResponseDto> CreateAsync(UserRequestDto user)
        {
            var model = UserMapper.ToModel(user);
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return UserMapper.ToResponseDto(model);
        }

        public async Task<UserResponseDto> UpdateAsync(UserRequestUpdateDto userRequestUpdateDto)
        {
            var userDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == userRequestUpdateDto.Id);
            var model = UserMapper.ToUpdateModel(userRequestUpdateDto);
            model.Senha = userDb.Senha;

            _context.Users.Update(model);
            await _context.SaveChangesAsync();

            return UserMapper.ToResponseDto(model);
        }

        public async Task<UserResponseDto?> GetByIdAsync(int idUser)
        {
            return UserMapper.ToResponseDto(await _context.Users.FirstOrDefaultAsync(x => x.Id == idUser));
        }
        public async Task UpdatePasswordAsync(UserRequestUpdatePasswordDto passDto)
        {
            var user = await GetUserModelByIdAsync(passDto.IdUser);
            user.Senha = PasswordHasher.ToBcrypt(passDto.NewPassword);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        private async Task<User> GetUserModelByIdAsync(int idUser)
        {
            return await _context.Users.FirstAsync(x => x.Id == idUser);
        }
        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return UserMapper.ToResponseDtoList(users);
        }

        public async Task DeleteAsync(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }


        }
    }


}
