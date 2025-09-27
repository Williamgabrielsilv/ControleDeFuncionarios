using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Repositories.Interfaces
{
    public interface IRegistroPontoRepository
    {

        Task<RegistroPonto?> GetByFuncionarioAndDateAsync(int funcionarioId, DateTime data);
        Task<List<RegistroPonto>> GetByFuncionarioAsync(int funcionarioId);
        Task<RegistroPonto> CreateAsync(RegistroPonto registro);
        Task UpdateAsync(RegistroPonto registro);
    }
}
