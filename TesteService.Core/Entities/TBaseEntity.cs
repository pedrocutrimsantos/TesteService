using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TesteService.Core.Entities
{
    public abstract class TBaseEntity
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!")]
        public DateTime ChangeDate { get; set; }
    }
}
