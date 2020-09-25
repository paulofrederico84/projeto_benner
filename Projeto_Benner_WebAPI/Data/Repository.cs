using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_Benner_WebAPI.Models;

namespace Projeto_Benner_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            this._context = context;
        }

        public void Add<T>(T entity) where T : class
        {
                _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
                _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
                _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
                return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<TabelaPreco[]> GetAllTabelaPrecoAsync()
        {
            IQueryable<TabelaPreco> query = _context.TabelaPreco;

            var start = new DateTime(2010, 1, 1); var end = new DateTime(2011, 1, 1);
            query = query.AsNoTracking().OrderBy(tp => tp.Id); //. Where(tp => tp.VigenciaFinal.Value.IsBetween(start, end));

            return await query.ToArrayAsync();
        }

        public async Task<TabelaPreco> GetTabelaPrecoAsyncById(int tabelaPrecoId)
        {
            IQueryable<TabelaPreco> query = _context.TabelaPreco;

                query = query.AsNoTracking()
                            .OrderBy(tp => tp.Id)
                            .Where(tp => tp.Id == tabelaPrecoId);

                  return await query.FirstOrDefaultAsync();     
        }

        public async Task<Veiculo[]> GetAllVeiculoAsync(bool includeEstacionamento)
        {
            IQueryable<Veiculo> query = _context.Veiculo;

                  if (includeEstacionamento)
                  {
                      query = query.Include(v => v.Estacionamento);                                   
                  }

                  query = query.AsNoTracking().OrderBy(v => v.Id);

                  return await query.ToArrayAsync();
        }

        public async Task<Veiculo> GetVeiculoAsyncById(int veiculoId)
        {
            IQueryable<Veiculo> query = _context.Veiculo;

                query = query.AsNoTracking()
                            .OrderBy(v => v.Id)
                            .Where(v => v.Id == veiculoId);

                return await query.FirstOrDefaultAsync();     
        }

        public async Task<Veiculo[]> GetVeiculoAsyncByPlaca(string veiculoPlaca, bool includeEstacionamento)
        {
            IQueryable<Veiculo> query = _context.Veiculo;

            if (includeEstacionamento)
            {
                query = query.Include(v => v.Estacionamento);
            }

                query = query.AsNoTracking()
                               .OrderBy(v => v.Placa)
                               .Where(v => v.Placa == veiculoPlaca);
                return await query.ToArrayAsync();
        }

        public async Task<Estacionamento[]> GetAllEstacionamentoAsync(bool includeVeiculo)
        {
            IQueryable<Estacionamento> query = _context.Estacionamento;

                  if (includeVeiculo)
                  {
                      query = query.Include(e => e.Veiculo);                                   
                  }

                  query = query.AsNoTracking().OrderBy(e => e.Id);

                  return await query.ToArrayAsync();
        }

        public async Task<Estacionamento> GetEstacionamentoAsyncById(int estacionamentoId)
        {
            IQueryable<Estacionamento> query = _context.Estacionamento;

                query = query.AsNoTracking()
                            .OrderBy(e => e.Id)
                            .Where(e => e.Id == estacionamentoId);

                  return await query.FirstOrDefaultAsync();     
        }

        public async Task<Estacionamento[]> GetAllEstacionamentoAsyncByVeiculoPlaca(string veiculoPlaca, bool includeVeiculo)
        {
            IQueryable<Estacionamento> query = _context.Estacionamento;

                  if (includeVeiculo)
                  {
                      query = query.Include(e => e.Veiculo);
                  }

                  query = query.AsNoTracking()
                               .OrderBy(e => e.Id)
                               .Where(e => e.Veiculo.Placa == veiculoPlaca);
                  return await query.ToArrayAsync();
        }





    }
}