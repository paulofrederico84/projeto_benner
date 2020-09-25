using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Benner_WebAPI.Data;
using Projeto_Benner_WebAPI.Models;

namespace Projeto_Benner_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public VeiculoController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _repositorio.GetAllVeiculoAsync(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("veiculoId={veiculoId}")]
        public async Task<IActionResult> Get(int veiculoId)
        {
            try
            {
                var result = await _repositorio.GetVeiculoAsyncById(veiculoId);
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
                var result = await _repositorio.GetVeiculoAsyncByPlaca(veiculoPlaca, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Veiculo veiculo)
        {
            try
            {
                _repositorio.Add(veiculo);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(veiculo);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("veiculoId={veiculoId}")]
        public async Task<IActionResult> Put(int veiculoId, Veiculo veiculo)
        {
            try
            {
                var veiculoCadastrado = await _repositorio.GetVeiculoAsyncById(veiculoId);
                if (veiculoCadastrado == null)
                {
                    return NotFound();
                }

                _repositorio.Update(veiculo);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(veiculo);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("veiculoId={veiculoId}")]
        public async Task<IActionResult> Put(int veiculoId)
        {
            try
            {
                var veiculo = await _repositorio.GetVeiculoAsyncById(veiculoId);
                if (veiculo == null)
                {
                    return NotFound();
                }

                _repositorio.Delete(veiculo);

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