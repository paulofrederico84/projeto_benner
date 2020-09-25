using Microsoft.EntityFrameworkCore;
using Projeto_Benner_WebAPI.Models;

namespace Projeto_Benner_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Estacionamento> Estacionamento { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<TabelaPreco> TabelaPreco { get; set; }
    }
}