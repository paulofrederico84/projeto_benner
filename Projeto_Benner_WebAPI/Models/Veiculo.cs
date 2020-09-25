using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Benner_WebAPI.Models 
{
    public class Veiculo 
    {
        public Veiculo() {}
        public Veiculo (int id, string placa, string marca, string modelo, string cor) 
        {
            this.Id = id;
            this.Placa = placa;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Cor = cor;
        }

        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public IEnumerable<Estacionamento> Estacionamento { get; set; }
    }
}