using System;
using System.ComponentModel.DataAnnotations;

namespace DevIO.App.ViewModels
{
    public class BaseViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; }
    }
}
