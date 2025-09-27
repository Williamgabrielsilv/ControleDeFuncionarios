namespace Projeto_ControleDeFuncionários.Models
{
    public class RegistroPonto
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime Data { get; set; }
        public DateTime Checking { get; set; }
        public DateTime? Checkout { get; set; }
        public string? Observacao { get; set; }
    }
}
