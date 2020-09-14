using DevIo.Business.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class CarroViewModel : BaseViewModel
    {
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Cor { get; set; }
        [Required]
        [DisplayName("Tipo de veículo")]
        public TipoVeiculo TipoVeiculo { get; set; }
        [Required]
        public TamanhoVeiculo Tamanho { get; set; }
        public Guid MensalId { get; set; }
    }
}
