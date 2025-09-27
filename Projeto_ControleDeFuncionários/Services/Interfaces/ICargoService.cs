using Projeto_ControleDeFuncionários.DTOs.Request;
using Projeto_ControleDeFuncionários.DTOs.Response;
using Projeto_ControleDeFuncionários.DTOs.Update;

namespace Projeto_ControleDeFuncionários.Services.Interfaces
{
    public interface ICargoService
    {
        Task<CargoResponseDto> RegisterAsync(CargoRequestDto cargoRequestDto);
        Task<IEnumerable<CargoResponseDto>> GetAllAsync();
        Task<CargoResponseDto> GetByIdAsync(int id);
        Task<bool> UpdateCargoAsync(int id, CargoUpdateDto cargoUpdateDto);
        Task<bool> DeleteCargoAsync(int id);
    }
}
