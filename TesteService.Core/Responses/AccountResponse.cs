using System;
using System.Collections.Generic;
using System.Text;
using TesteService.Core.Entities;

namespace TesteService.Core.Responses
{
  public  class AccountResponse
    {
        
       
        public float Cash { get; set; }
        public virtual TUser User { get; set; }
    }
}
