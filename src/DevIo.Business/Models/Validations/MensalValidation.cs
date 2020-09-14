using FluentValidation;
using System;

namespace DevIo.Business.Models.Validations
{
    public class MensalValidation : AbstractValidator<Mensal>
    {
        public MensalValidation()
        {
            RuleFor(x => x.ValidadeContrato)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.ValorMulta)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.ValidadeContrato)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(90)).WithMessage("A validade mínima do contrato é de 3 meses");

            RuleFor(x => x.Carro.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.Carro.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(x => x.Cliente.Cpf)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
            
        }
    }
}
