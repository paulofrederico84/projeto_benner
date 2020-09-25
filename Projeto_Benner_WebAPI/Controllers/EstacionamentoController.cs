using System.Runtime.CompilerServices;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Benner_WebAPI.Data;
using Projeto_Benner_WebAPI.Models;
using Projeto_Benner_WebAPI.Servico.interfaces;

namespace Projeto_Benner_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstacionamentoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        private readonly ICalculoServico _calculoServico;
        public EstacionamentoController(IRepository repositorio, ICalculoServico calculoServico)
        {
            _repositorio = repositorio;
            _calculoServico = calculoServico;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _repositorio.GetAllEstacionamentoAsync(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("estacionamentoId={estacionamentoId}")]
        public async Task<IActionResult> Get(int estacionamentoId)
        {
            try
            {
                var result = await _repositorio.GetEstacionamentoAsyncById(estacionamentoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("veiculoPlaca={veiculoPlaca}")]
        public async Task<IActionResult> GetByPlaca(string veiculoPlaca)
        {
            try
            {
                var result = await _repositorio.GetAllEstacionamentoAsyncByVeiculoPlaca(veiculoPlaca, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estacionamento estacionamento)
        {
            try
            {
                _repositorio.Add(estacionamento);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(estacionamento);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("estacionamentoId={estacionamentoId}")]
        public async Task<IActionResult> Put(int estacionamentoId, Estacionamento estacionamento)
        {
            try
            {
                var estacionamentoCadastrado = await _repositorio.GetEstacionamentoAsyncById(estacionamentoId);
                if (estacionamentoCadastrado == null)
                {
                    return NotFound();
                }

                estacionamento.ValorTotal = this._calculoServico.CalcularValorEstacionamento(estacionamentoCadastrado);
                
                estacionamento.DataHoraSaida = DateTime.Now;

                _repositorio.Update(estacionamento);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(estacionamento);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("estacionamentoId={estacionamentoId}")]
        public async Task<IActionResult> Put(int estacionamentoId)
        {
            try
            {
                var estacionamento = await _repositorio.GetEstacionamentoAsyncById(estacionamentoId);
                if (estacionamento == null)
                {
                    return NotFound();
                }

                _repositorio.Delete(estacionamento);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok("Deletado");
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();    
        }

    }
}