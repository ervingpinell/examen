using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAnalisisArchivos.Models.DTO
{
    public class UserLiveCycleDTO
    {
       public int Session { get; set; }
       public UserDTO User { get; set; }
       public AtmParameterDTO Atm { get; set; }
    }
}