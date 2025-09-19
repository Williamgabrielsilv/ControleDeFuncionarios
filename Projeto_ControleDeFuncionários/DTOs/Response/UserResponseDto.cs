namespace Projeto_ControleDeFuncionários.DTOs.Response
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DataDeNascimento { get; set; }
        public bool Valid { get; set; }
        public int DepartamentoId { get; internal set; }
    }
}
