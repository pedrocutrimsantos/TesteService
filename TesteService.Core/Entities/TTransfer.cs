using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteService.Core.Entities
{
    public class TTransfer : TBaseEntity
    {

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public float Value { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public DateTime OperationDate { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        [ForeignKey(name: "Sender")]
        public Guid SendID { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        [ForeignKey(name: "Receiver")]
        public Guid ReceiptID { get; set; }

        [Required(ErrorMessage = "O CAMPO {0} É OBRIGATÓRIO!", AllowEmptyStrings = false)]
        public OperationStatus OperationStatus { get; set; }
        public virtual TUser Sender { get; set; }
        public virtual TUser Receiver { get; set; }
    }


    public enum OperationStatus
    {
        OK = 1,
        Fail = 2
    }
}
