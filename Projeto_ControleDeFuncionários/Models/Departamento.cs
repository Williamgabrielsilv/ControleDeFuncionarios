using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleDeFuncionários.Models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }

        [Required(ErrorMessage = "Nome do departamento obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Descrição do departamento obrigatória")]
        public string Descricao { get; set; }



    }
}
