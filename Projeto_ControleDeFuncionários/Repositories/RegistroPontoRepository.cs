using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Banco_de_dados;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;

namespace Projeto_ControleDeFuncionários.Repositories
{
        public class RegistroPontoRepository(banco_de_dados context) : IRegistroPontoRepository
        {
            private readonly banco_de_dados _context = context; //Construtor
        

            public async Task<RegistroPonto?> GetByFuncionarioAndDateAsync(int funcionarioId, DateTime data)
            {
                return await _context.RegistrosPonto
                .FirstOrDefaultAsync(r => r.FuncionarioId == funcionarioId && r.Data == data);
            }

            public async Task<List<RegistroPonto>> GetByFuncionarioAsync(int funcionarioId)
            {
                return await _context.RegistrosPonto
                    .Where(r => r.FuncionarioId == funcionarioId)
                    .OrderByDescending(r => r.Data)
                    .ToListAsync();
            }

            public async Task<RegistroPonto> CreateAsync(RegistroPonto registro)
            {
                _context.RegistrosPonto.Add(registro);
                await _context.SaveChangesAsync();
                return registro;
            }

            public async Task UpdateAsync(RegistroPonto registro)
            {
                _context.RegistrosPonto.Update(registro);
                await _context.SaveChangesAsync();
            }
        }

}
