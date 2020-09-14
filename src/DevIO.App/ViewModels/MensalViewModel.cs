using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class MensalViewModel : BaseViewModel
    {
        [Required]
        [DisplayName("Validade do contrato")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ValidadeContrato { get; set; }
        [Required]
        [DisplayName("Preço mensal")]
        public double ValorPrecoMensal { get; set; }
        [Required]
        [DisplayName("Data de pagamento")]
        public DateTime DataPagamento { get; set; }
        [Required]
        [DisplayName("Valor da multa")]
        public double ValorMulta { get; set; }

        public CarroViewModel Carro { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public List<PagamentoViewModel> Pagamentos { get; set; }
    }
}
