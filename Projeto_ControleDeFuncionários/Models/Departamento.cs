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

        /*public List<User> Funcionarios { get; set; }

        public Departamento()
        {
            Funcionarios = new List<User>();  // Inicializa a lista
        }

        // Método para adicionar funcionário ao departamento
        public void AdicionarFuncionario(User usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "Funcionário não pode ser nulo.");

            // Verifica se o funcionário já não está alocado em um departamento
            if (usuario.DepartamentoId != 0)
                throw new InvalidOperationException("Este funcionário já pertence a um departamento.");

            // Adiciona o funcionário à lista do departamento
            Funcionarios.Add(usuario);

            // Atualiza a propriedade DepartamentoId do usuário
            usuario.DepartamentoId = this.DepartamentoId;
        }*/


    }
}
