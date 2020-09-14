using System;
using System.Collections.Generic;
using System.Text;

namespace DevIo.Business.Models
{
    public class Preco : Entity
    {
        public string NomeTipoPreco { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
    }
}
