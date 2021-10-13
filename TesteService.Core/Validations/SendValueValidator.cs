using FluentValidation;
using TesteService.Core.Commands;

namespace TesteService.Core.Validations
{
    public class SendValueValidator : AbstractValidator<SendValue>
    {
        public SendValueValidator()
        {
            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("O VALOR DA TRANSFERÊNCIA DEVE SER MAIOR QUE ZERO!");
        }
    }
}
