using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Benner_WebAPI.Models 
{
    public class TabelaPreco 
    {
        public TabelaPreco() {}
        public TabelaPreco (int id, DateTime vigenciaInicial, DateTime vigenciaFinal, float valorHora) 
        {
            this.Id = id;
            this.VigenciaInicial = vigenciaInicial;
            this.VigenciaFinal = vigenciaFinal;
            this.ValorHora = valorHora;
        }

        [Key]
        public int Id { get; set; }
        public DateTime VigenciaInicial { get; set; }
        public DateTime VigenciaFinal { get; set; }
        public float ValorHora { get; set; }
        public IEnumerable<Estacionamento> Estacionamento { get; set; }

    }
}