namespace Projeto_ControleDeFuncionários.DTOs.Update
{
    public class UserUpdateDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string? Senha { get; set; }
        public int? DepartamentoId { get; set; }
    }
}