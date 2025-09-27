namespace Projeto_ControleDeFuncionários.DTOs.Request
{
    public class AfastamentoRequestDto
    {
        public int FuncionarioId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }
}
