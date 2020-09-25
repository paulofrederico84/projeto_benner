using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Benner_WebAPI.Data;
using Projeto_Benner_WebAPI.Models;

namespace Projeto_Benner_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TabelaPrecoController : ControllerBase
    {
        private readonly IRepository _repositorio;
        public TabelaPrecoController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }    

        [HttpGet]
        public async Task<IActionResult> GetAction()
        {
            try
            {
                var result = await _repositorio.GetAllTabelaPrecoAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("tabelaPrecoId={tabelaPrecoId}")]
        public async Task<IActionResult> Get(int tabelaPrecoId)
        {
            try
            {
                var result = await _repositorio.GetTabelaPrecoAsyncById(tabelaPrecoId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(TabelaPreco tabelaPreco)
        {
            try
            {
                _repositorio.Add(tabelaPreco);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(tabelaPreco);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpPut("tabelaPrecoId={tabelaPrecoId}")]
        public async Task<IActionResult> Put(int tabelaPrecoId, TabelaPreco tabelaPreco)
        {
            try
            {
                var tabelaPrecoCadastrado = await _repositorio.GetTabelaPrecoAsyncById(tabelaPrecoId);
                if (tabelaPrecoCadastrado == null)
                {
                    return NotFound();
                }

                _repositorio.Update(tabelaPreco);

                if (await _repositorio.SaveChangesAsync())
                {
                    return Ok(tabelaPreco);
                }
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            return BadRequest();
        }

        [HttpDelete("tabelaPrecoId={tabelaPrecoId}")]
        public async Task<IActionResult> Put(int tabelaPrecoId)
        {
            try
            {
                var tabelaPreco = await _repositorio.GetTabelaPrecoAsyncById(tabelaPrecoId);
                if (tabelaPreco == null)
                {
                    return NotFound();
                }

                _repositorio.Delete(tabelaPreco);

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