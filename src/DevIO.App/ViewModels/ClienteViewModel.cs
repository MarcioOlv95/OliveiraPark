using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class ClienteViewModel : BaseViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        [Required]
        public string Cpf { get; set; }
        public Guid MensalId { get; set; }
    }
}
