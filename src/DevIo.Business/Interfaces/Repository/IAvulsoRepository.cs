using DevIo.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIo.Business.Interfaces.Repository
{
    public interface IAvulsoRepository : IRepository<Avulso>
    {
        Task<Avulso> ObterPelaPlaca(string placa);
        Task<List<Avulso>> ObterTodosByDiaAtual();
    }
}
