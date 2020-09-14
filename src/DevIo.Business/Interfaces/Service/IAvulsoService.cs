using DevIo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Business.Interfaces.Service
{
    public interface IAvulsoService : IService<Avulso>, IDisposable
    {
        Task<Avulso> ObterPelaPlaca(string placa);
        double CalcularPreco(Guid id, DateTime dataSaida);
        Task<List<Avulso>> ObterTodosByDiaAtual();
        Task<bool> HaVagaDisponivel();
    }
}
