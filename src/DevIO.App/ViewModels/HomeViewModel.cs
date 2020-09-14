using System.Collections.Generic;

namespace DevIO.App.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<AvulsoViewModel> AvulsoViewModelL { get; set; }
        public bool HaVagaDisponivel { get; set; }
    }
}
