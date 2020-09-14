using System;
using System.Collections.Generic;

namespace DevIo.Business.Models
{
    public class Mensal : Entity
    {
        public DateTime ValidadeContrato { get; set; }
        public double ValorPrecoMensal { get; set; }
        public DateTime DataPagamento { get; set; }
        public double ValorMulta { get; set; }

        public Carro Carro { get; set; }
        public Cliente Cliente { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
    }
}
