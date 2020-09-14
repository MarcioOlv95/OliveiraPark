using System;

namespace DevIo.Business.Models
{
    public class Cliente : Entity
    {
        public Guid MensalId { get; set; }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cpf { get; set; }

        public Mensal Mensal { get; set; }
    }
}
