using System;
using System.Collections.Generic;
using System.Text;

namespace DevIo.Business.Models
{
    public class Avulso : Entity
    {
        public string Placa { get; set; }
        public DateTime HrEntrada { get; set; }
        public DateTime HrSaida { get; set; }
        public double PrecoFinal { get; set; }

    }
}
