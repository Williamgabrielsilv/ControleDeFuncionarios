namespace Projeto_ControleDeFuncionários.DTOs.Response
{
    public class RegistroPontoResponseDto
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime Data { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public string? Observacao { get; set; }
        public string? CargaHoraria { get; set; }
    }
}
