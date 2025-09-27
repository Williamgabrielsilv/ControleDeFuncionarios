using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.DTOs.Update;
using Projeto_ControleDeFuncionários.Mappers;
using Projeto_ControleDeFuncionários.Models;
using Projeto_ControleDeFuncionários.Repositories;
using Projeto_ControleDeFuncionários.Repositories.Interfaces;
using Projeto_ControleDeFuncionários.Services.Interfaces;

namespace Projeto_ControleDeFuncionários.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        public CargoService(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }
        public async Task<CargoResponseDto> RegisterAsync(CargoRequestDto cargoRequestDto)
        {
            //Transforma o request para o modelo do banco
            var cargo = CargoMapper.ToModel(cargoRequestDto);
            var response = await _cargoRepository.CreateAsync(cargo);
            return response;
        }
        public async Task<IEnumerable<CargoResponseDto>> GetAllAsync()
        {
            var Cargos = await _cargoRepository.GetAllAsync();

            var response = CargoMapper.ToResponseDtoList((List<Cargo>)Cargos);


            return response;
        }
        public async Task<CargoResponseDto> GetByIdAsync(int id)
        {
            var Cargo = await _cargoRepository.GetByIdAsync(id);

            return Cargo;        
        }
        public async Task<bool> UpdateCargoAsync(int id, CargoUpdateDto cargoUpdateDto)
        {
            var Cargo = await _cargoRepository.GetByIdAsync(id);
            if (Cargo == null)
                return false;
            CargoMapper.UpdateModelFromDto(Cargo, cargoUpdateDto);

            //await _cargoRepository.UpdateAsync(Cargo);

            return true;        
        }
        public async Task<bool> DeleteCargoAsync(int id)
        {
            var Cargo = await _cargoRepository.GetByIdAsync(id);
            if (Cargo == null)
                return false;
            await _cargoRepository.DeleteAsync(id);
            return true;
        }



    }
}
