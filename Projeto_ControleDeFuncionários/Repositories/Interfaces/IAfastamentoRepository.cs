using Projeto_ControleDeFuncionários.Banco_de_dados;
using Projeto_ControleDeFuncionários.Models;
using System;

namespace Projeto_ControleDeFuncionários.Repositories.Interfaces
{
    public interface IAfastamentoRepository
    {
        Task<Afastamento> CreateAsync(Afastamento afastamento);
        Task<List<Afastamento>> GetAllAsync();
        Task<Afastamento?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<bool> EstaAfastadoAsync(int funcionarioId, DateTime data);
    }


}
