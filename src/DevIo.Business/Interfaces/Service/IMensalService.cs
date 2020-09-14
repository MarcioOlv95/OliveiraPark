using DevIo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Business.Interfaces.Service
{
    public interface IMensalService : IService<Mensal>, IDisposable
    {
        Task<Mensal> ObterPorIDLoadClienteAndCarroAndPagamentos(Guid id);
    }
}
