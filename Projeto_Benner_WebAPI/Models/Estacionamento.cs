using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Benner_WebAPI.Models {
    public class Estacionamento 
    {
        public Estacionamento() {}
        
        public Estacionamento (int id, DateTime dataHoraEntrada, DateTime dataHoraSaida, int veiculoId, int tabelaPrecoId, double valorTotal) 
        {
            this.Id = id;
            this.DataHoraEntrada = dataHoraEntrada;
            this.DataHoraSaida = dataHoraSaida;
            this.VeiculoId = veiculoId;
            this.TabelaPrecoId = tabelaPrecoId;            
            this.ValorTotal = valorTotal;
        }

        [Key]
        public int Id { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime DataHoraSaida { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int TabelaPrecoId { get; set; }
        public TabelaPreco TabelaPreco { get; set; }
        public double ValorTotal { get; set; }

    }
}