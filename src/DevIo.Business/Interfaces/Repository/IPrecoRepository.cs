using DevIo.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIo.Business.Interfaces.Repository
{
    public interface IPrecoRepository
    {
        Task<List<Preco>> ObterTodos();
    }
}
