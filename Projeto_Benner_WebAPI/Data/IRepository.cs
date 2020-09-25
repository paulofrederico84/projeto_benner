using System.Threading.Tasks;
using Projeto_Benner_WebAPI.Models;

namespace Projeto_Benner_WebAPI.Data
{
    public interface IRepository
    {
        //Geral
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //TabelaPreco
        Task<TabelaPreco[]> GetAllTabelaPrecoAsync();
        Task<TabelaPreco> GetTabelaPrecoAsyncById(int tabelaPrecoId);

        //Veiculo
        Task<Veiculo[]> GetAllVeiculoAsync(bool includeEstacionamento);
        Task<Veiculo> GetVeiculoAsyncById(int veiculoId);
        Task<Veiculo[]> GetVeiculoAsyncByPlaca(string veiculoPlaca, bool includeEstacionamento);

        //Estacionamento
        Task<Estacionamento[]> GetAllEstacionamentoAsync(bool includeVeiculo);
        Task<Estacionamento> GetEstacionamentoAsyncById(int estacionamentoId);
        Task<Estacionamento[]> GetAllEstacionamentoAsyncByVeiculoPlaca(string veiculoPlaca, bool includeVeiculo);

        


        
    }
}