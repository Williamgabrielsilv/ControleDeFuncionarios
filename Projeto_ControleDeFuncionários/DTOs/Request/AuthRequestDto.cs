using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleDeFuncionários.DTOs.Request
{
    public class AuthRequestDto
    {
        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
