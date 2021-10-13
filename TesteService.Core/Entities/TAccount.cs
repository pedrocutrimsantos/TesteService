using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TesteService.Core.Entities
{
    public class TAccount : TBaseEntity
    {

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public Guid UserID { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public float Cash { get; set; }
        public virtual TUser User { get; set; }
    }
}
