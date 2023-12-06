using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAnalisisArchivos.Models.DTO
{
    public class AtmParameterDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The 'ten_bill' field is required.")]
        [Range(0, 999, ErrorMessage = "The value of 'ten_bill' must be between 0 and 999.")]
        public int TenBill { get; set; }

        [Required(ErrorMessage = "The 'twenty_bill' field is required.")]
        [Range(0, 999, ErrorMessage = "The value of 'twenty_bill' must be between 0 and 999.")]
        public int TwentyBill { get; set; }

        [Required(ErrorMessage = "The 'balance' field is required.")]
        [Range(0, 9999999, ErrorMessage = "The value of 'balance' must be between 0 and 9999999.")]
        public int Balance { get; set; }

        [Required(ErrorMessage = "The 'out_service_message' field is required.")]
        [StringLength(100, ErrorMessage = "The maximum length for 'out_service_message' is 100 characters.")]
        public string OutServiceMessage { get; set; }
    }
}