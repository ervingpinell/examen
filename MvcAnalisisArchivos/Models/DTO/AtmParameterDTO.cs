using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAnalisisArchivos.Models.DTO
{
    public class AtmParameterDTO
    {
        public int Id { get; set; }
        public int TenBill { get; set; }
        public int TwentyBill { get; set; }
        public int Balance { get; set; }
        public string OutServiceMessage { get; set; }

    }
}