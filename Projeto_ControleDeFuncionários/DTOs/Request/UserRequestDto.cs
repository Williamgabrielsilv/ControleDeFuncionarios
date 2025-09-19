namespace Projeto_ControleDeFuncionários.DTOs.Request
{
    public class UserRequestDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DataDeNascimento { get; set; }
        public int DepartamentoId { get; internal set; }
    }
}
