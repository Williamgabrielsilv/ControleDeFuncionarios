using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleDeFuncionários.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; }
        public decimal Salario { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório")]  
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        public string Senha { get; set; }

        [Required(ErrorMessage = "Cargo obrigatório")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Data de admissão obrigatória")]
        public DateTime DataDeAdmissao { get; set; }
        public string DataDeNascimento { get; set; }
        public string Convenio { get; set; }
    }
}
