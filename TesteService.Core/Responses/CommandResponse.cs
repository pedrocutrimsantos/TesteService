
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteService.Core.Responses
{
    public class CommandResponse
    {
        public CommandResponse(bool status)
        {
            OperationStatus = status;
        }

        public CommandResponse(bool status, string message)
        {
            Message = message;
            OperationStatus = status;
        }

        public CommandResponse(bool status, string message, List<ValidationFailure> errors)
        {
            Message = message;
            OperationStatus = status;
            ValidationErrors = errors;
        }

        public bool OperationStatus { get; set; }
        public string Message { get; set; }
        public List<ValidationFailure> ValidationErrors { get; set; }
    }
}
