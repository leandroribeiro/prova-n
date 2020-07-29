using Exercicio03.API.Model;
using FluentValidation;

namespace Exercicio03.API.Validations
{
    public class MultiploDeOnzeRequestValidator : AbstractValidator<MultiploDeOnzeRequest>
    {
        public MultiploDeOnzeRequestValidator()
        {
            RuleFor(x => x.numbers).NotEmpty().Must(list => list.Length >= 1).WithMessage("Deve ser passado no mínimo um número para validação");
            RuleForEach(x => x.numbers).Matches(@"^[\d]+$").WithMessage("Deve ser um número");
        }
    }
}