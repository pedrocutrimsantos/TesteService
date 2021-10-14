using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TesteService.Core.Entities
{
    public class TUser : TBaseEntity
    {

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public int CPF_CNPJ { get; set; }

        public TypeUser TypeUser { get; set; }
        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public string Password { get; set; }
        public virtual TAccount Account { get; set; }

        public virtual List<TTransfer> Receivers { get; set; }
        public virtual List<TTransfer> Senders { get; set; }
    }

    public enum TypeUser
    {
        LOJISTA = 0,
        NORMAL = 1
    }
}
