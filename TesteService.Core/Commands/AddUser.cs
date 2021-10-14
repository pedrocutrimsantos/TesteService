using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Entities;
using TesteService.Core.Responses;

namespace TesteService.Core.Commands
{
    public class AddUser : IRequest<CommandResponse>
    {
        public string Name { get; set; }

        public int CPF_CNPJ { get; set; }

        public TypeUser TypeUser { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }


}
