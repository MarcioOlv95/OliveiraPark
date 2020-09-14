using DevIo.Business.Notificacoes;
using System.Collections.Generic;

namespace DevIo.Business.Interfaces.Service
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
