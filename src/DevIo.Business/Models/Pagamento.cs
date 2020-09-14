using System;

namespace DevIo.Business.Models
{
    public class Pagamento : Entity
    {
        public Guid MensalId { get; set; }

        public int MesPagamento { get; set; }
        public bool PagamentoRealizado { get; set; }

        public Mensal Mensal { get; set; }
    }
}
