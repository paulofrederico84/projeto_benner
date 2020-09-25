using System.Runtime.CompilerServices;
using System;
using Projeto_Benner_WebAPI.Models;
using Projeto_Benner_WebAPI.Servico.interfaces;

namespace Projeto_Benner_WebAPI.Servico
{
    public class CalculoServico : ICalculoServico
    {
        public double CalcularValorEstacionamento(Estacionamento estacionamento)
        {
            var valorDaHora = estacionamento.TabelaPreco.ValorHora;

            TimeSpan totalHorasMinutos = DateTime.Now.Subtract(estacionamento.DataHoraEntrada);

            double valorMinuto = 0;
            
            if ((int)totalHorasMinutos.Minutes > 10)
            {
               valorMinuto = valorDaHora / 2;
            }
          
            return ((int)totalHorasMinutos.TotalHours * valorDaHora) + valorMinuto;
        } 
    }
}