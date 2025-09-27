using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;


namespace Projeto_ControleDeFuncionários.Repositories.Interfaces
{
    public interface ICargoRepository
    {
        // CREATE
        Task<CargoResponseDto> CreateAsync(Cargo cargo);
        // READ
        Task<CargoResponseDto?> GetByIdAsync(int id);
        Task<IEnumerable<Cargo>> GetAllAsync();
        // UPDATE
        Task UpdateAsync(CargoRequestDto cargo);
        // DELETE
        Task DeleteAsync(int id);
    }
}
