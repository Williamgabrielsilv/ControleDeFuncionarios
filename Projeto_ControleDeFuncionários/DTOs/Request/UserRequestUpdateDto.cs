using Projeto_ControleDeFuncionários.Enums;

namespace Projeto_ControleDeFuncionários.DTOs.Request
{

    public class UserRequestUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public LevelAccessEnum LevelAccess { get; set; }
        public string DataDeNascimento { get; set; }
    }
}
