using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Interfaces.Service;
using DevIo.Business.Models;
using DevIo.Business.Models.Validations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Business.Services
{
    public class AvulsoService : BaseService<Avulso>, IAvulsoService
    {
        private readonly IAvulsoRepository _avulsoRepository;
        private readonly IPrecoRepository _precoRepository;
        private readonly IConfiguration _configuration;

        public AvulsoService(IAvulsoRepository avulsoRepository,
                            IPrecoRepository precoRepository,
                            INotificador notificador,
                            IConfiguration configuration) : base(avulsoRepository, notificador)
        {
            _avulsoRepository = avulsoRepository;
            _precoRepository = precoRepository;
            _configuration = configuration;
        }

        public async Task<Avulso> ObterPelaPlaca(string placa)
        {
            return await _avulsoRepository.ObterPelaPlaca(placa);
        }

        public async override Task Adicionar(Avulso avulso)
        {
            if (!ExecutarValidacao(new AvulsoValidation(), avulso))
                return;

            avulso.Ativo = true;
            avulso.DataCadastro = DateTime.Now;

            await _avulsoRepository.Adicionar(avulso);
        }

        public async override Task Atualizar(Avulso avulso)
        {
            if (!ExecutarValidacao(new AvulsoValidation(), avulso))
                return;

            avulso.DataAlteracao = DateTime.Now;

            await _avulsoRepository.Atualizar(avulso);
        }

        public double CalcularPreco(Guid id, DateTime dataSaida)
        {
            if (dataSaida == DateTime.MinValue)
            {
                Notificar("A data de saída deve ser preenchida");
                return 0;
            }

            var precos = _precoRepository.ObterTodos().Result.Where(x => x.NomeTipoPreco == "Avulso");

            var avulso = _avulsoRepository.ObterPorID(id).Result;

            var tempoEstacionamento = dataSaida - avulso.HrEntrada;

            double precoFinal = 0;

            if (tempoEstacionamento.Days > 0)
                precoFinal = precos.FirstOrDefault(x => x.Descricao.Contains("Diária")).Valor * tempoEstacionamento.Days;

            //1 hr
            if (tempoEstacionamento.Hours <= 1 && tempoEstacionamento.Days == 0)
                precoFinal = precos.FirstOrDefault(x => x.Descricao.Contains("1")).Valor;

            if (tempoEstacionamento.Hours > 1)
            {
                var demaisHrs = tempoEstacionamento.Hours - 1;
                precoFinal = precoFinal + (precos.FirstOrDefault(x => x.Descricao.Contains("Demais")).Valor * demaisHrs) + precos.FirstOrDefault(x => x.Descricao.Contains("1")).Valor;
            }

            return precoFinal;
        }

        public Task<List<Avulso>> ObterTodosByDiaAtual()
        {
            return _avulsoRepository.ObterTodosByDiaAtual();
        }

        public async Task<bool> HaVagaDisponivel()
        {
            int numeroVagas = Convert.ToInt32(_configuration["NumeroVagasTotal"]);
            var ocupantes = await _avulsoRepository.ObterTodosByDiaAtual();
            ocupantes = ocupantes.Where(x => x.HrSaida == DateTime.MinValue).ToList();

            return ocupantes.Count() < numeroVagas;

        }
    }
}
