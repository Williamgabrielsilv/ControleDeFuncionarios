using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleDeFuncionários.Models
{


    public class HistoricoSalario
    {
        public int HistoricoSalarioId { get; set; }

        [Required(ErrorMessage = "Valor obrigatório")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Data de alteração obrigatória")]
        public DateTime DataAlteracao { get; set; }
        public string Motivo { get; set; }
        public int UsuarioId { get; set; }
    }

}
