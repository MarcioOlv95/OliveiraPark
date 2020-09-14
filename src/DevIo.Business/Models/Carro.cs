using System;

namespace DevIo.Business.Models
{
    public class Carro : Entity
    {
        public Guid MensalId { get; set; }

        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Cor { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public TamanhoVeiculo Tamanho { get; set; }

        public Mensal Mensal { get; set; }
    }
}
