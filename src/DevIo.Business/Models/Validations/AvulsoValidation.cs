using FluentValidation;
using System;

namespace DevIo.Business.Models.Validations
{
    public class AvulsoValidation : AbstractValidator<Avulso>
    {
        public AvulsoValidation()
        {
            RuleFor(f => f.HrEntrada)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            When(f => f.HrSaida != DateTime.MinValue, () =>
            {
                RuleFor(f => f.HrSaida).GreaterThan(f => f.HrEntrada).WithMessage("O horário de saída deve ser maior que o de entrada");
                RuleFor(f => f.PrecoFinal).NotEmpty().WithMessage("O preço deve ser fornecido.");
            });
        }
    }
}
