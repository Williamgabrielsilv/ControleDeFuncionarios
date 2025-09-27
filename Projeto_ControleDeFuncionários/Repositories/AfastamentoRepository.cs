using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Banco_de_dados;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using System;

namespace Projeto_ControleDeFuncionários.Repositories
{
    public class AfastamentoRepository : IAfastamentoRepository
    {
        private readonly banco_de_dados _context;

        public AfastamentoRepository(banco_de_dados context)
        {
            _context = context;
        }

        public async Task<Afastamento> CreateAsync(Afastamento afastamento)
        {
            _context.Afastamentos.Add(afastamento);
            await _context.SaveChangesAsync();
            return afastamento;
        }

        public async Task<List<Afastamento>> GetAllAsync()
        {
            return await _context.Afastamentos.ToListAsync();
        }

        public async Task<Afastamento?> GetByIdAsync(int id)
        {
            return await _context.Afastamentos.FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var afastamento = await _context.Afastamentos.FindAsync(id);
            if (afastamento != null)
            {
                _context.Afastamentos.Remove(afastamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EstaAfastadoAsync(int funcionarioId, DateTime data)
        {
            return await _context.Afastamentos.AnyAsync(a =>
                a.FuncionarioId == funcionarioId &&
                a.DataInicio <= data &&
                a.DataFim >= data);
        }
    }

}
