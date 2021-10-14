using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Entities;

namespace TesteService.Core.Responses
{
    public class UsersResponse
    {
        public string Name { get; set; }

        public int CPF_CNPJ { get; set; }

        public TypeUser TypeUser { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
    }
}
