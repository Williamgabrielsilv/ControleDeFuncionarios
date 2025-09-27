using Projeto_ControleDeFuncionários.Enums;
using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleDeFuncionários.DTOs.Request
{
    public class UserRequestDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Endereço obrigatório")]
        public string Endereco { get; set; }
        public decimal Salario { get; set; }
        [Required(ErrorMessage = "Cargo obrigatório")]
        public string Cargo { get; set; }
        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        public string Senha { get; set; }
        [Required]
        public LevelAccessEnum LevelAccess { get; set; }
        public string Celular { get; set; }
        public string DataDeNascimento { get; set; }
        public string Convenio { get; set; }
        [Required(ErrorMessage = "Data de admissão obrigatória")]
        public DateTime DataDeAdmissao { get; set; }
    }

}
