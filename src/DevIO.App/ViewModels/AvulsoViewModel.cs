using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class AvulsoViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O preenchimento da placa é obrigatório")]
        [StringLength(7, ErrorMessage = "A placa deve conter 7 dígitos", MinimumLength = 7)]
        public string Placa { get; set; }
        
        [Required]
        [DisplayName("Horário de entrada")]
        public DateTime HrEntrada { get; set; }
        
        [DisplayName("Horário de saída")]
        public DateTime? HrSaida { get; set; }
        
        [DisplayName("Preço final")]
        public double PrecoFinal { get; set; }
    }
}
