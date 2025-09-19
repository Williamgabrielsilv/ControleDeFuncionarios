using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleDeFuncionários.Models
{
    public class ControlePonto
    {
        // Lista de registros de ponto de todos os funcionários
        public List<RegistroPonto> RegistrosPonto { get; set; }

        public ControlePonto()
        {
            RegistrosPonto = new List<RegistroPonto>();
        }

        // Método para registrar o check-in (entrada)
        public void RegistrarCheckin(int usuarioId)
        {
            var registro = new RegistroPonto
            {
                UsuarioId = usuarioId,
                Data = DateTime.Now,
                TipoEvento = TipoEvento.Checkin,
                Status = "Presente"
            };

            RegistrosPonto.Add(registro);
            Console.WriteLine($"Funcionário {usuarioId} fez check-in às {registro.Data}.");
        }

        // Método para registrar o check-out (saída)
        public void RegistrarCheckout(int usuarioId)
        {
            var registro = new RegistroPonto
            {
                UsuarioId = usuarioId,
                Data = DateTime.Now,
                TipoEvento = TipoEvento.Checkout,
                Status = "Ausente"
            };

            RegistrosPonto.Add(registro);
            Console.WriteLine($"Funcionário {usuarioId} fez check-out às {registro.Data}.");
        }

        // Método para obter o histórico de ponto de um funcionário específico
        public List<RegistroPonto> ObterHistoricoPonto(int usuarioId)
        {
            return RegistrosPonto.Where(r => r.UsuarioId == usuarioId).ToList();
        }
    }

}
