using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Responses;

namespace TesteService.Core.Commands
{
    public class AddCash : IRequest<CommandResponse>
    {
        public int CpfCnpj { get; set; }
        public float Value { get; set; }
    }
}
