using Projeto_ControleDeFuncionários.Models;

namespace Projeto_ControleDeFuncionários.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
