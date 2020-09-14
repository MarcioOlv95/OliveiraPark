using DevIo.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIo.Business.Interfaces.Repository
{
    public interface IMensalRepository : IRepository<Mensal>
    {
        Task<Mensal> ObterPorIDLoadClienteAndCarroAndPagamentosAsync(Guid id);
    }
}
