using DevIo.Business.Interfaces.Repository;
using DevIo.Business.Interfaces.Service;
using DevIo.Business.Models;
using DevIo.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIo.Business.Services
{
    public abstract class BaseService<TEntity> : IService<TEntity> where TEntity : Entity, new()
    {
        private readonly IRepository<TEntity> _repository;
        private readonly INotificador _notificador;

        public BaseService(IRepository<TEntity> repository,
                            INotificador notificador)
        {
            _repository = repository;
            _notificador = notificador;
        }

        public virtual async Task Adicionar(TEntity obj)
        {
            obj.Ativo = true;
            obj.DataCadastro = DateTime.Now;

            await _repository.Adicionar(obj);
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            obj.DataAlteracao = DateTime.Now;
            await _repository.Atualizar(obj);
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Buscar(predicate);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public virtual async Task<TEntity> ObterPorID(Guid id)
        {
            return await _repository.ObterPorID(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        public virtual async Task Remover(Guid id)
        {
            var obj = await ObterPorID(id);
            obj.Ativo = false;

            await _repository.Atualizar(obj);
        }

        public virtual async Task<int> SaveChanges()
        {
            return await _repository.SaveChanges();
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<VT, VE>(VT validacao, VE entidade) where VT : AbstractValidator<VE> where VE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
                return true;

            Notificar(validator);

            return false;
        }
    }
}
