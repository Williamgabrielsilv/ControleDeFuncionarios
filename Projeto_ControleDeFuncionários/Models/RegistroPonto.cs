namespace Projeto_ControleDeFuncionários.Models
{
        public class RegistroPonto
        {
            public int UsuarioId { get; set; }
            public DateTime Data { get; set; }
            public TipoEvento TipoEvento { get; set; }
            public string Status { get; set; }
        }

    public enum TipoEvento
    {
        Checkin,
        Checkout
    }
    
}
