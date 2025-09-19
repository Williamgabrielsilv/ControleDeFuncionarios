using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleDeFuncionários.Models;

public class Ferias
{
    public int Id { get; set; }  // Chave primária
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
