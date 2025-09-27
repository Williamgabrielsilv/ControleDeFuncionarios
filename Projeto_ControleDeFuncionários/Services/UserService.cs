using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using Projeto_ControleDeFuncionários.Services.Interfaces;

namespace Projeto_ControleDeFuncionários.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new InvalidDataException("Usuário não encontrado");

            await _userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var response = await _userRepository.GetAllAsync();
            return response;
        }

        public async Task<UserResponseDto> GetByIdAsync(int id)
        {   var response = await _userRepository.GetByIdAsync(id);
            if (response == null)
                throw new InvalidDataException("Usuário não encontrado");
            return response;
        }

        public async Task<UserResponseDto> RegisterAsync(UserRequestDto userDto)
        {
            bool existingUser = await _userRepository.GetByEmailAsync(userDto.Email) != null;
            if (existingUser)
                throw new InvalidOperationException("E-mail já cadastrado");

            var response = await _userRepository.CreateAsync(userDto);
            return response;
        }

        public async Task<UserResponseDto> UpdateAsync(UserRequestUpdateDto userDto)
        {
            try
            {
                bool existingUser = await _userRepository.GetByIdAsync(userDto.Id) != null;
                if (!existingUser)
                    throw new InvalidDataException("Usuário não encontrado");

                return await _userRepository.UpdateAsync(userDto); ;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task UpdatePasswordAsync(UserRequestUpdatePasswordDto passDto)
        {
            bool existingUser = await _userRepository.GetByIdAsync(passDto.IdUser) != null;
            if (!existingUser)
                throw new InvalidDataException("Usuário não encontrado");

            await _userRepository.UpdatePasswordAsync(passDto);
        }
    }

}
