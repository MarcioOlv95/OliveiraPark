using DevIo.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIo.Business.Interfaces.Service
{
    public interface IPrecoService
    {
        Task<List<Preco>> ObterTodos();
    }
}
