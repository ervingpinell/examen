using MvcAnalisisArchivos.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAnalisisArchivos.Models.DAO
{
    public class AtmParameterDAO
    {

        public AtmParameterDTO GetAtmParameter()
        {
            AtmParameterDTO parameter = new AtmParameterDTO();
            parameter.Id = 1;
            parameter.TenBill = 10;
            parameter.TwentyBill = 5;
            parameter.Balance = 200;
            parameter.OutServiceMessage = "ATM out of service";

            return parameter;

        }

    }
}