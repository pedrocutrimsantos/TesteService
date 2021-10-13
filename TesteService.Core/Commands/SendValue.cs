using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Responses;

namespace TesteService.Core.Commands
{
    public class SendValue : IRequest<CommandResponse>
    {
        public float Value { get; set; }

        public int CpfCnpjSend { get; set; }

        public int CpfCnpjReceive { get; set; }
    }
}
