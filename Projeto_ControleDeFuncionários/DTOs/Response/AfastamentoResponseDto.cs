namespace Projeto_ControleDeFuncionários.DTOs.Response
{
    public class AfastamentoResponseDto
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }

}
