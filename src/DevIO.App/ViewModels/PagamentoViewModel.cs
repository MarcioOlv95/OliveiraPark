using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.App.ViewModels
{
    public class PagamentoViewModel : BaseViewModel
    {
        public int MesPagamento { get; set; }
        public bool PagamentoRealizado { get; set; }

        public Guid MensalId { get; set; }
    }
}
