using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Banco_de_dados;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;

namespace Projeto_ControleDeFuncionários.Repositories
{
    public class CargoRepository(banco_de_dados context) : ICargoRepository
    {
        private readonly banco_de_dados _context = context; //Construtor

        public async Task<CargoResponseDto> CreateAsync(Cargo Cargo)
        {
            _context.Cargos.Add(Cargo);
            await _context.SaveChangesAsync();
            return CargoMapper.ToResponseDto(Cargo);
        }


        // READ
        public async Task<CargoResponseDto?> GetByIdAsync(int id)
        {
            return CargoMapper.ToResponseDto(await _context.Cargos.FindAsync(id));
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return await _context.Cargos.ToListAsync();
        }

        // UPDATE
        public async Task UpdateAsync(CargoRequestDto Cargo)
        {
            var rensponse = CargoMapper.ToModel(Cargo);
            _context.Cargos.Update(rensponse);
            await _context.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var Cargo = await _context.Cargos.FindAsync(id);
            if (Cargo != null)
            {
                _context.Cargos.Remove(Cargo);
                await _context.SaveChangesAsync();
            }
        }

    }
}
