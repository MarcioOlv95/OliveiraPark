using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Interfaces.Service;
using DevIo.Business.Models;
using DevIo.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIo.Business.Services
{
    public class MensalService : BaseService<Mensal>, IMensalService
    {
        private readonly IMensalRepository _mensalRepository;
        private readonly IPrecoRepository _precoRepository;

        public MensalService(IMensalRepository mensalRepository,
                            INotificador notificador,
                            IPrecoRepository precoRepository) : base(mensalRepository, notificador)
        {
            _mensalRepository = mensalRepository;
            _precoRepository = precoRepository;
        }

        public override async Task Adicionar(Mensal mensal)
        {
            if (!ExecutarValidacao(new MensalValidation(), mensal))
                return;

            mensal.DataCadastro = DateTime.Now;
            mensal.Ativo = true;

            mensal.Carro.DataCadastro = DateTime.Now;
            mensal.Carro.Ativo = true;

            mensal.Cliente.DataCadastro = DateTime.Now;
            mensal.Cliente.Ativo = true;

            CalcularPrecoMensal(mensal);

            await _mensalRepository.Adicionar(mensal);
        }

        public override async Task Atualizar(Mensal mensal)
        {
            if (!ExecutarValidacao(new MensalValidation(), mensal))
                return;

            mensal.DataAlteracao = DateTime.Now;
            mensal.Cliente.DataCadastro = DateTime.Now;
            mensal.Carro.DataCadastro = DateTime.Now;

            CalcularPrecoMensal(mensal);

            await _mensalRepository.Atualizar(mensal);
        }

        public async Task<Mensal> ObterPorIDLoadClienteAndCarroAndPagamentos(Guid id)
        {
            return await _mensalRepository.ObterPorIDLoadClienteAndCarroAndPagamentosAsync(id);
        }

        private void CalcularPrecoMensal(Mensal mensal)
        {
            var precos = _precoRepository.ObterTodos().Result.Where(x => x.NomeTipoPreco == "Mensal");

            var duracaoContrato = mensal.ValidadeContrato - DateTime.Now;

            if (duracaoContrato.TotalDays < 90)
            {
                mensal.ValorPrecoMensal = precos.FirstOrDefault(x => x.Descricao == "Trimestral").Valor;
            }
            else
            {
                mensal.ValorPrecoMensal = precos.FirstOrDefault(x => x.Descricao == "Semestral").Valor;
            }
        }
    }
}
