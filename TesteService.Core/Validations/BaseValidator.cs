using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteService.Core.Validations
{
    public class BaseValidator
    {
        public static ValidationResult Validate<T>(AbstractValidator<T> validator, T model)
        {
            return validator.Validate(model);
        }
    }
}
