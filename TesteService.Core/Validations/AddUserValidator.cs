using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Commands;

namespace TesteService.Core.Validations
{
    public class AddUserValidator : AbstractValidator<AddUser>
    {
        public AddUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O CAMPO NOME É OBRIGATÓRIO!")
                .MinimumLength(3).WithMessage("O CAMPO NOME DEVE CONTER NO MINÍMO 3 CARACTERES")
                .MaximumLength(100).WithMessage("O CAMPO NOME NÃO PODE CONTER MAIS DE 100 CARACTERES");
            RuleFor(x => x.CPF_CNPJ)
                .GreaterThan(0).WithMessage("O CAMPO CPF/CPNJ É OBRIGATÓRIO!");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O CAMPO EMAIL É OBRIGATÓRIO!");
            RuleFor(x => x.TypePerson)
                .NotNull().WithMessage("O CAMPO TIPO PESSOA É OBRIGATÓRIO!");
            RuleFor(x => x.TypeUser).NotNull().WithMessage("O CAMPO TIPO USUÁRIO É OBRIGATÓRIO!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("O CAMPO SENHA É OBRIGATÓRIO!");
        }
    }
}
