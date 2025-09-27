namespace Projeto_ControleDeFuncionários.DTOs.Update
{
    public class CargoUpdateDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal? SalarioBase { get; set; }
    }
}
