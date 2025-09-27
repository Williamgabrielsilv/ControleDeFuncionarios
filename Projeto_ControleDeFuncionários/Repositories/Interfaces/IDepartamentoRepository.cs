using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Repositories.Interfaces
{
    public interface IDepartamentoRepository
    {
        // CREATE
        Task<DepartamentoResponseDto> CreateAsync(Departamento departamento);
        // READ
        Task<Departamento?> GetByIdAsync(int id);
        Task<IEnumerable<Departamento>> GetAllAsync();
        // UPDATE
        Task UpdateAsync(Departamento departamento);
        // DELETE
        Task DeleteAsync(int id);
    }
}
