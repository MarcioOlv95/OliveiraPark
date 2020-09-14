using DevIo.Business.Interfaces;
using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Interfaces.Service;
using DevIo.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIo.Business.Services
{
    public class PrecoService : IPrecoService
    {
        private readonly IPrecoRepository _precoRepository;

        public PrecoService(IPrecoRepository precoRepository)
        {
            _precoRepository = precoRepository;
        }

        public async Task<List<Preco>> ObterTodos()
        {
            return await _precoRepository.ObterTodos();
        }
    }
}
