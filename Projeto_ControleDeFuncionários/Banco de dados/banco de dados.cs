using Microsoft.EntityFrameworkCore;
using Projeto_ControleDeFuncionários.Models;        

namespace Projeto_ControleDeFuncionários.Banco_de_dados
{
    public class banco_de_dados : DbContext
    {
        public banco_de_dados(DbContextOptions<banco_de_dados> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
