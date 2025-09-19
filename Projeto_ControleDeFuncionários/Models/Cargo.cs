using System.ComponentModel.DataAnnotations;
namespace Projeto_ControleDeFuncionários.Models

{
    public class Cargo
    {
        public int CargoId { get; set; }

        [Required(ErrorMessage = "Nome do cargo obrigatório")]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Salário base obrigatório")]
        public decimal SalarioBase { get; set; }
    }
}
